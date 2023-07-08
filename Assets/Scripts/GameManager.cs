using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool hasStart;
    [SerializeField] private float speed;
 
    [SerializeField] private GameObject movingPart;

    [SerializeField] private GameObject[] R1;
    [SerializeField] private GameObject[] R2;
    [SerializeField] private GameObject[] R3;
    [SerializeField] private GameObject[] R4;

    [SerializeField] private List<GameObject> Keys;

    [SerializeField] private float downSide_Y;

    private Dictionary<string, int> Pairs = new Dictionary<string, int>();

    private float protectionTime = 0.5f;

    KeyCode[] keyCodes =
    {
        KeyCode.Alpha0,
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z
    };

    private List<KeyCode> AllKeys = new List<KeyCode>();

    void Start()
    {
        hasStart = false;
        AllKeys.AddRange(keyCodes);
    }

    void Update()
    {
        if (hasStart)
        {
            movingPart.transform.Translate(Vector2.down * Time.deltaTime * speed, Space.Self);
        }
        if (Keys[0].transform.position.y < downSide_Y)
        {
            SwitchKeyboard();
        }
        InputUpdate();

        Debug.Log(Pairs.Count);
    }


    private void SwitchKeyboard()
    {
        Vector2 pos = Keys[0].transform.localPosition;
        pos.y+=4;
        Keys[0].transform.localPosition = pos;
        Keys.Add(Keys[0]);
        Keys.RemoveAt(0);
    }


    private void InputUpdate()
    {
        //0
        //if (Input.GetKeyUp(KeyCode.Alpha1))
        //{
        //    if(Pairs.ContainsKey("0"))
        //    {
        //        EventBus.Publish(new TentacleLoose(Pairs["0"]));
        //        Pairs.Remove("0");
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    if (!Pairs.ContainsKey("0")&&Pairs.Count<6)
        //    {
        //        int handIdx = GetSpareHand();
        //        Pairs.Add("0", handIdx);
        //        EventBus.Publish(new TentacleTouch(handIdx, R1[0].transform.position));
        //    }
        //}
        for (int i = 0; i < AllKeys.Count; i++)
        {
            string key;
            if (i < 10)
            {
                key = i.ToString();
            }
            else
            {
                key = (((char)(i+87)).ToString());
            }
            if (Input.GetKeyUp(AllKeys[i]))
            {                
                if (Pairs.ContainsKey(key))
                {
                    EventBus.Publish(new TentacleLoose(Pairs[key]));
                    Pairs.Remove(key);
                    Debug.Log(key + " up");
                }
            }
            if (Input.GetKeyDown(AllKeys[i]))
            {
                if (!Pairs.ContainsKey(key) && Pairs.Count < 6)
                {
                    int handIdx = GetSpareHand();
                    Pairs.Add(key, handIdx);
                    EventBus.Publish(new TentacleTouch(handIdx,GameObject.Find(key).transform.position));
                    Debug.Log(key + " down");
                }
            }
        }
    }

    private int GetSpareHand()
    {
        for (int i = 0; i < 6; i++)
        {
            if (!Pairs.ContainsValue(i))
            {
                return i;
            }
        }
        Debug.LogError("WrongHand");
        return -1;
    }
}
