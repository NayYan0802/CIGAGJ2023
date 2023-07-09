using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

        public int toScene;
        public void OnStartGame() {
                SceneManager.LoadScene(toScene);
        }
}
