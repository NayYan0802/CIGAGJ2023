using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("score");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);     
    }
}
