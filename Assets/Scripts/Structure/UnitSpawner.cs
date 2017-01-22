using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO {
    public class UnitSpawner : MonoBehaviour {
        public Squad squadPrefab;

        public float dirSpawnAngle = 0.0f;

        public float distanceSpawn = 1.0f;

        public List<Transform> waypoints;

        public Vector3 SpawnDir
        {
            get { return Quaternion.Euler(0, 0, dirSpawnAngle) * transform.right; }
        }

        public Vector3 SpawnPos
        {
            get { return transform.position + SpawnDir* distanceSpawn; }
        }

        void Start()
        {
            SpawnSquad();
        }

        private void SpawnSquad()
        {
            List<Vector3> points = new List<Vector3>();
            foreach (Transform t in waypoints)
            {
                points.Add(t.position);
            }

            Squad temp = Instantiate<Squad>(squadPrefab);
            temp.transform.position = SpawnPos;
            temp.waypoints = points;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, SpawnPos);
        }
    }
}
