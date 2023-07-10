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

    [SerializeField] private GameObject BG1;
    [SerializeField] private GameObject BG2;

    [SerializeField] private GameObject[] R1;
    [SerializeField] private GameObject[] R2;
    [SerializeField] private GameObject[] R3;
    [SerializeField] private GameObject[] R4;

    [SerializeField] private bool[] _R1;
    [SerializeField] private bool[] _R2;
    [SerializeField] private bool[] _R3;
    [SerializeField] private bool[] _R4;

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

    [SerializeField] private float _obstaclePossibility;
    [SerializeField] private float LoseDeter;

    private float switchBG=0;

 
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
            float actualSpeed = speed * (1 + Camera.main.transform.position.y / 20);
            actualSpeed = Mathf.Clamp(actualSpeed, speed, speed * 2);
            Camera.main.transform.Translate(Vector2.up * Time.deltaTime * actualSpeed, Space.Self);
        }
        if (Keys[0].transform.position.y- Camera.main.transform.position.y < downSide_Y)
        {
            SwitchKeyboard();
        }
                if (Camera.main.transform.position.y > 56+15*switchBG) {
                        if (BG1.transform.position.y > BG2.transform.position.y) {
                                BG2.transform.Translate(Vector3.up * 30, Space.Self);                                
                        }
                        else {
                                BG1.transform.Translate(Vector3.up * 30, Space.Self);
                        }
                        switchBG++;
                }
        UIUpdate();
        InputUpdate();
        TentacleUpdate();
        Lose();

        //Debug.Log(Pairs.Count);
    }

    private void Lose()
    {
        if (body.position.y < Camera.main.transform.position.y - LoseDeter)
        {
            PlayerPrefs.SetString("score", score.text);
            Debug.Log(body.position.y + "   " + (Camera.main.transform.position.y - LoseDeter));
            SceneManager.LoadScene(3);
        }
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
            tentacleList[i].up = ((Vector2)TPoint[i].position - TRoot[i]).normalized;
            tentacleList[i].Rotate(Vector3.back, i<3 ? 13:-13) ;
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
        //Add Obstacles
        float obstaclePossibility = _obstaclePossibility * Camera.main.transform.position.y / 20;
        obstaclePossibility = Mathf.Clamp01(obstaclePossibility);
        switch (Keys[0].name)
        {
            case "R1":
                for (int i = 0; i < R1.Length; i++)
                {
                    if (UnityEngine.Random.value > obstaclePossibility)
                    {
                        _R1[i] = true;
                        R1[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        _R1[i] = false;
                        R1[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                break;
            case "R2":
                for (int i = 0; i < R2.Length; i++)
                {
                    if (UnityEngine.Random.value > obstaclePossibility)
                    {
                        _R2[i] = true;
                        R2[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        _R2[i] = false;
                        R2[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                break;
            case "R3":
                for (int i = 0; i < R3.Length; i++)
                {
                    if (UnityEngine.Random.value > obstaclePossibility)
                    {
                        _R3[i] = true;
                        R3[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        _R3[i] = false;
                        R3[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                break;
            case "R4":
                for (int i = 0; i < R4.Length; i++)
                {
                    if (UnityEngine.Random.value > obstaclePossibility)
                    {
                        _R4[i] = true;
                        R4[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }
                    else
                    {
                        _R4[i] = false;
                        R4[i].transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
                break;
            default:
                break;
        }
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
                    EventBus.Publish(new PlayAudioClip(0));
                    Pairs.Remove(key);
                    Debug.Log(key + " up");
                }
            }
            if (Input.GetKeyDown(AllKeys[i]))
            {
                GameObject thisKey = GameObject.Find(key);
                for (int j = 0; j < R1.Length; j++)
                {
                    if (R1[j] == thisKey && !_R1[j])
                    {
                        return;
                    }
                }
                for (int j = 0; j < R2.Length; j++)
                {
                    if (R2[j] == thisKey && !_R2[j])
                    {
                        return;
                    }
                }
                for (int j = 0; j < R3.Length; j++)
                {
                    if (R3[j] == thisKey && !_R3[j])
                    {
                        return;
                    }
                }
                for (int j = 0; j < R4.Length; j++)
                {
                    if (R4[j] == thisKey && !_R4[j])
                    {
                        return;
                    }
                }
                if (Pairs.Count > 5)
                {
                    hasStart = true;
                }
                if (!Pairs.ContainsKey(key) && Pairs.Count < 6)
                {
                    int handIdx = GetSpareHand(thisKey.transform.position);
                    Pairs.Add(key, handIdx);
                    EventBus.Publish(new TentacleTouch(handIdx, thisKey.transform.position));
                    Target[handIdx]= thisKey.transform.position;
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
