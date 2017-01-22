using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeardTwins.TO
{
    public class SceneController : MonoBehaviour
    {
        public void LoadScene(string name) {
            SceneManager.LoadScene(name);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}