using UnityEngine;

namespace Game.Scripts.UI.Menu
{ 
    public class MenuController : MonoBehaviour
    {
        [ SerializeField ]
        private GameObject collectablesCounter;

        [ SerializeField ]
        private GameObject steps;
        
        private void Awake()
        {
            Time.timeScale = 0f;
            collectablesCounter.SetActive(false);
            steps.SetActive(false);
        }

        public void Play()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            collectablesCounter.SetActive(true);
            steps.SetActive(true);
        }

        public void Setting()
        {

        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
