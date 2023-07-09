using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour {

        public int toScene;

        public void OnFinishOpening() {
                SceneManager.LoadScene(toScene);
        }
}
