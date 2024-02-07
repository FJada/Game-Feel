using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArrowGame : MonoBehaviour
{
    public GameObject arrow_up;
    public GameObject arrow_down;
    public GameObject arrow_left;
    public GameObject arrow_right;
    public TimeProperties timeLimit;
    public float pos = 0;
    public float arrowCount = 0;
    public int arrowIndex = 0;
    public List<GameObject> arrowList;
    public List<GameObject> cloneList;
    public float time = 0;
    public bool playing = true;
    public bool complete = false;
    public HealthScript healthScript;

    void Start()
    {
        DontDestroyOnLoad(timeLimit);

        healthScript.SetMaxHealth(timeLimit.limit);

        pos = 1-arrowCount;
        arrowIndex = 0;
        arrowList = new List<GameObject>();
        cloneList = new List<GameObject>();
        for (int i = 0; i < arrowCount; i++)
        {
            AddArrow();
            arrowList[i].SetActive(true);
            pos += 2;
        }
        time = timeLimit.limit;
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            if (time > 0 && !complete)
            {
                CheckInput();
                if (arrowIndex == arrowCount)
                {
                    complete = true;
                }
            }
            else
            {
                BallResult((arrowIndex) / arrowCount);
                Debug.Log(arrowIndex/arrowCount);
                timeLimit.count++;
                timeLimit.limit = (timeLimit.limit/2f + 0.3f);
                playing = false;
                SceneManager.LoadScene("Game");
            }
            time -= Time.deltaTime;
            healthScript.SetHealth(time);
        }
    }

    void AddArrow()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                arrowList.Add(arrow_up);
                cloneList.Add(Instantiate(arrow_up, transform.position + Vector3.right * pos, Quaternion.identity));
                break;
            case 1:
                arrowList.Add(arrow_down);
                cloneList.Add(Instantiate(arrow_down, transform.position + Vector3.right * pos, Quaternion.identity));
                break;
            case 2:
                arrowList.Add(arrow_left);
                cloneList.Add(Instantiate(arrow_left, transform.position + Vector3.right * pos, Quaternion.identity));
                break;
            case 3:
                arrowList.Add(arrow_right);
                cloneList.Add(Instantiate(arrow_right, transform.position + Vector3.right * pos, Quaternion.identity));
                break;
        }
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            timeLimit.limit = 10;
            timeLimit.count = 0;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (arrowList[arrowIndex] == arrow_up)
            {
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowUpGood");
            }
            else
            {
                Debug.Log("failedUp");
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (arrowList[arrowIndex] == arrow_down)
            {
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowDGood");
            }
            else
            {
                Debug.Log("failedD");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (arrowList[arrowIndex] == arrow_left)
            {
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowLGood");
            }
            else
            {
                Debug.Log("failedL");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrowList[arrowIndex] == arrow_right)
            {
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowRGood");
            }
            else
            {
                Debug.Log("failedR");
            }
        }
    }

    void BallResult(float successPercent)
    {
        //move to miss scene
        //move to scene x
        //move to scene y
        //move to scene z
        //move to perfect if timelimit is under a certain threshhold
    }
}
