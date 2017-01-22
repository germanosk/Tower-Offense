using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public Text resourcesText;
    public Text wavesText;

    public GameObject playerUI;

    public void UpdateWaveText(int count)
    {
        wavesText.text = count.ToString();
    }
    public void UpdateResourcesText(int count)
    {
        resourcesText.text = count.ToString();
    }

    public void ActivePlayerUI(bool active)
    {
        playerUI.SetActive(active);
    }
}
