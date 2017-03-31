using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BeardTwins.TO
{
    public class SceneController : MonoBehaviour
    {
        public int timeScale = 1;
        public float defaultFixedDeltaTime;


        public void Awake()
        {
            defaultFixedDeltaTime = Time.fixedDeltaTime;
        }

        public void LoadScene(string name) {
            SceneManager.LoadScene(name);
        }

        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void Quit()
        {
            Application.Quit();
        }

        //Method used by the FowardButton
        public void ChangeTimeScale() {
            if (timeScale == 1) {
                ++this.timeScale;
                Time.fixedDeltaTime = Time.fixedDeltaTime * this.timeScale;
            }
            else {
                timeScale = 1;
                Time.fixedDeltaTime = this.defaultFixedDeltaTime;
            }
            Time.timeScale = timeScale;
        }
    }
}