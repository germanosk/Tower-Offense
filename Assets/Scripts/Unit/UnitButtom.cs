using UnityEngine;
using UnityEngine.UI;

namespace BeardTwins.TO
{
    public class UnitButtom : MonoBehaviour
    {
        public Squad prefabSquad;
        public int cost;

        public Text costText;

        void Awake()
        {
            costText.text = "$ "+cost.ToString();
        }

        public void Buy()
        {
            GameController.Instance.Buy(prefabSquad, cost);
        }
    }
}
