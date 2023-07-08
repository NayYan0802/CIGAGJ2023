using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool hasStart;
    [SerializeField] private float speed;
    [SerializeField] private float speed1;
    [SerializeField] private float speed2;
 
    [SerializeField] private GameObject movingPart;

    [SerializeField] private GameObject[] R1;
    [SerializeField] private GameObject[] R2;
    [SerializeField] private GameObject[] R3;
    [SerializeField] private GameObject[] R4;

    [SerializeField] private Text score;

    [SerializeField] private List<GameObject> Keys;

    [SerializeField] private float downSide_Y;

    [SerializeField] private List<Transform> tentacleList;
    [SerializeField] private Transform body;
    [SerializeField] private Vector2 bodyTarget;
    [SerializeField] private float bodyOffset;
    [SerializeField] private Vector2[] TRoot = new Vector2[6];
    [SerializeField] private Vector2[] Target = new Vector2[6];
    [SerializeField] private Transform[] TPoint;
 
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
        //hasStart = false;
        AllKeys.AddRange(keyCodes);
    }

    void Update()
    {
        if (hasStart)
        {
            Camera.main.transform.Translate(Vector2.up * Time.deltaTime * speed, Space.Self);
        }
        if (Keys[0].transform.position.y- Camera.main.transform.position.y < downSide_Y)
        {
            SwitchKeyboard();
        }
        UIUpdate();
        InputUpdate();
        TentacleUpdate();

        //Debug.Log(Pairs.Count);
    }

    private void TentacleUpdate()
    {
        bodyTarget = (Target[0] + Target[1] + Target[2] + Target[3] + Target[4] + Target[5]) / 6;
        bodyTarget.y -= bodyOffset;
        body.Translate((bodyTarget - (Vector2)body.position).normalized * speed2 * Time.deltaTime, Space.Self);
        TRoot[0] = body.position;
        TRoot[0].x -= 2;
        TRoot[1] = body.position;
        TRoot[1].x -= 1;
        TRoot[2] = body.position;
        TRoot[3] = body.position;
        TRoot[4] = body.position;
        TRoot[4].x += 1;
        TRoot[5] = body.position;
        TRoot[5].x += 2;
        for (int i = 0; i < 6; i++)
        {
            TPoint[i].Translate((Target[i] - (Vector2)TPoint[i].position).normalized*speed1*Time.deltaTime, Space.Self);
            tentacleList[i].position = TRoot[i];
            tentacleList[i].up = (Vector2)TPoint[i].position - TRoot[i];
            Vector3 newscale = tentacleList[i].localScale;
            newscale.y= Vector2.Distance((Vector2)TPoint[i].position, TRoot[i]) * 0.17f;
            tentacleList[i].localScale = newscale;
        }
    }

    private void UIUpdate()
    {
        score.text = ((int)(Camera.main.transform.position.y)).ToString() + "cm";
    }

    private void SwitchKeyboard()
    {
        Vector2 pos = Keys[0].transform.localPosition;
        pos.y+=4;
        Keys[0].transform.localPosition = pos;
        //switch (Keys[0].name)
        //{
        //    case "R1":
        //        for (int i = 0; i < R1.Length; i++)
        //        {
        //            Vector2 _pos = R1[i].transform.localPosition;
        //            _pos.y += 4;
        //            R1[i].transform.localPosition = _pos;
        //        }
        //        break;
        //    case "R2":
        //        for (int i = 0; i < R2.Length; i++)
        //        {
        //            Vector2 _pos = R2[i].transform.localPosition;
        //            _pos.y += 4;
        //            R2[i].transform.localPosition = _pos;
        //        }
        //        break;
        //    case "R3":
        //        for (int i = 0; i < R3.Length; i++)
        //        {
        //            Vector2 _pos = R3[i].transform.localPosition;
        //            _pos.y += 4;
        //            R3[i].transform.localPosition = _pos;
        //        }
        //        break;
        //    case "R4":
        //        for (int i = 0; i < R4.Length; i++)
        //        {
        //            Vector2 _pos = R4[i].transform.localPosition;
        //            _pos.y += 4;
        //            R4[i].transform.localPosition = _pos;
        //        }
        //        break;
        //    default:
        //        break;
        //}
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
                    int handIdx = GetSpareHand(GameObject.Find(key).transform.position);
                    Pairs.Add(key, handIdx);
                    EventBus.Publish(new TentacleTouch(handIdx,GameObject.Find(key).transform.position));
                    Target[handIdx]= GameObject.Find(key).transform.position;
                    Debug.Log(key + " down");
                }
            }
        }
    }

    private int GetSpareHand(Vector3 position)
    {
        float dst = 1000;
        int idx = -1;
        for (int i = 0; i < 6; i++)
        {
            if (!Pairs.ContainsValue(i)&& Vector2.Distance(Target[i], position)<dst)
            {
                dst = Vector2.Distance(Target[i], position);
                idx = i;
            }
        }
        return idx;
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
    }

    public void OnResume()
    {
        Time.timeScale = 1.0f;
    }

    public void OnRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
}
