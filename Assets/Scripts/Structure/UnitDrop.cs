using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO {
    public class UnitDrop : MonoBehaviour {
        public List<Squad> squadPrefabs;

        public float dirSpawnAngle = 0.0f;

        public float distanceSpawn = 1.0f;

        public List<Transform> waypoints;

        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;
        }

        public Vector3 SpawnDir
        {
            get { return Quaternion.Euler(0, 0, dirSpawnAngle) * transform.right; }
        }

        public Vector3 SpawnPos
        {
            get { return transform.position + SpawnDir* distanceSpawn; }
        }
        
        public void SpawnSquad()
        {
            if(squadPrefabs.Count > 0)
            {
                List<Vector3> points = new List<Vector3>();
                foreach (Transform t in waypoints)
                {
                    points.Add(t.position);
                }

                Squad temp = Instantiate<Squad>(squadPrefabs[0]);
                temp.transform.position = SpawnPos;
                temp.waypoints = points;
                squadPrefabs.RemoveAt(0);
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, SpawnPos);
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Player") && squadPrefabs.Count > 0)
            {
                SpawnSquad();
            }
        }

        void OnMouseDown()
        {
            if(spriteRenderer.enabled )
            {
                Squad squad = GameController.Instance.RequestSquad();

                if(squad != null)
                {
                    squadPrefabs.Add(squad);
                }
            }
        }

        public void WaitingDrop(bool active)
        {
            spriteRenderer.enabled = active;
        }
    }
}
