using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BeardTwins.TO
{
    public class SpawnController : MonoBehaviour
    {
        public List<UnitDrop> spawner;


        public void Play()
        {
            foreach(UnitDrop drop in spawner)
            {
                drop.SpawnSquad();
            }
        }
    }
}
