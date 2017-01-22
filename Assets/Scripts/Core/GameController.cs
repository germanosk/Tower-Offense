using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class GameController : Singleton<GameController>
    {
        private Player player;
        private SpawnController spawnController;
        private UIController uiController;

        private Squad tempSquad;
        private int squadCount=0;
        void Awake()
        {
            player = GetComponent<Player>();
            spawnController = GetComponent<SpawnController>();
            uiController = GetComponent<UIController>();
            uiController.UpdateResourcesText(player.resources);

        }

        public void AddValue(int ammount)
        {
            player.resources += ammount;
            uiController.UpdateResourcesText(player.resources);
        }

        public void Play()
        {
            player.waveCount++;
            spawnController.Play();
            uiController.UpdateWaveText(player.waveCount);
            uiController.ActivePlayerUI(false);
        }

        public void Buy(Squad squad, int cost)
        {
            if ( player.resources -cost >=0)
            {
                player.resources -= cost;
                uiController.UpdateResourcesText(player.resources);
                tempSquad = squad;
                uiController.ActivePlayerUI(false);
                spawnController.WaitingDrop(true);
            }
        }

        public Squad RequestSquad()
        {
            Squad result = tempSquad;
            if( tempSquad != null)
            {
                tempSquad = null;
                uiController.ActivePlayerUI(true);
                spawnController.WaitingDrop(false);
                squadCount++;
            }
            return result;
        }

        public void SquadDown()
        {
            squadCount--;
            if(squadCount <= 0)
            {
                squadCount = 0;
                uiController.ActivePlayerUI(true);
            }
        }

        public void Victory()
        {
            uiController.Victory();
        }
    }
}