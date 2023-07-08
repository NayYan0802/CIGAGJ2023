using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool hasStart;
    [SerializeField] private float speed;
    [SerializeField] private GameObject movingPart;
    // Start is called before the first frame update
    void Start()
    {
        hasStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStart)
        {

        }
    }
}
