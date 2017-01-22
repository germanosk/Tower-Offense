using System.Collections.Generic;
using UnityEngine;

namespace BeardTwins.TO
{
    public class GameController : Singleton<GameController>
    {
        public void AddValue(int ammount)
        {
            Debug.Log("Player won $" + ammount);
        }
    }
}