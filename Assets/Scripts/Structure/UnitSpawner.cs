using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO {
    public class UnitSpawner : MonoBehaviour {
        public Squad squadPrefab;

        public float dirSpawnAngle = 0.0f;

        public Vector3 SpawnDir
        {
            get { return Quaternion.Euler(0, 0, dirSpawnAngle) * transform.right; }
        }

        public Vector3 SpawnPos
        {
            get { return transform.position + SpawnDir; }
        }

        void Start()
        {
            SpawnSquad();
        }

        private void SpawnSquad()
        {
            Squad temp = Instantiate<Squad>(squadPrefab);
            temp.transform.position = SpawnPos;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Vector3 dirSpawn = SpawnDir;
            Gizmos.DrawLine(transform.position, transform.position+dirSpawn);
        }
    }
}
