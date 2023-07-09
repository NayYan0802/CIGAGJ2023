using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour {
        public int toScene;
        public void OnFinishKnife() {
                SceneManager.LoadScene(toScene);
        }
}
