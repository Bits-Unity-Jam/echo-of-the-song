using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.UI.Menu
{ 
    public class MenuController : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 0f;
        }

        public void Play()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
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
