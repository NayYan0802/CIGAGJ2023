using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Text>().text = PlayerPrefs.GetString("score");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);     
    }
}
