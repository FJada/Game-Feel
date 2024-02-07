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
    public float bufferTime = 0;
    public bool playing = true;
    public bool complete = false;
    public HealthScript healthScript;
    public SEffectPlayer soundEffectPlayer;
    public Shake shaker;
    public Shake shaker2;
    public TextMeshProUGUI streakUI;
    public GameObject player;
    public ParticleSystem ParticleSystem;
    public bool onFire = false;

    void Start()
    {
        DontDestroyOnLoad(timeLimit);

        streakUI.text = "STREAK: " + timeLimit.streak;
        healthScript.SetMaxHealth(timeLimit.limit);
        soundEffectPlayer.organ.pitch = timeLimit.pitch;

        ParticleSystem.Pause();
        player = GameObject.Find("Player");
        player.transform.Translate(-9, -1.0f, 0);

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
            streakUI.text = "STREAK: " + timeLimit.streak;
            if (timeLimit.streak > 19)
            {
                ParticleSystem.Emit(100);
            }
            if (timeLimit.streak == 19)
            {
                soundEffectPlayer.powerUp.Play();
            }
            if (time > 0 && !complete)
            {
                CheckInput();
                if (arrowIndex == arrowCount)
                {
                    complete = true;
                }
                time -= Time.deltaTime;
                healthScript.SetHealth(time);
            }
            else
            {
                if (bufferTime < 0)
                {
                    if (complete)
                    {
                        Debug.Log(arrowIndex / arrowCount);
                        timeLimit.count++;
                        timeLimit.limit = (timeLimit.limit / 1.5f + 0.3f);
                        bufferTime = bufferTime * 0.4f;
                        playing = false;
                        SceneManager.LoadScene("Game");
                    }
                    else
                    {
                        timeLimit.limit = 10;
                        timeLimit.count = 0;
                        timeLimit.streak = 0;
                        timeLimit.pitch = 1.0f;
                        SceneManager.LoadScene("Title");
                    }
                }
                else
                {
                    bufferTime -= Time.deltaTime;
                }
            }
            if (time < 2*timeLimit.limit/3)
            {
                shaker.ShakeMe(time);
                shaker2.ShakeMe(time);
            }
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
            timeLimit.streak = 0;
            timeLimit.pitch = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (arrowList[arrowIndex] == arrow_up)
            {
                if (arrowIndex == arrowCount - 1)
                {
                    soundEffectPlayer.audioBig.Play();
                    soundEffectPlayer.organ.Play();
                    timeLimit.pitch += 0.2f;
                }
                else
                {
                    player.transform.Translate(2.0f, 0, 0);
                    soundEffectPlayer.audioHit.Play();
                }
                timeLimit.streak++;
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowUpGood");
            }
            else
            {
                timeLimit.streak = 0;
                Debug.Log("failedUp");
                soundEffectPlayer.audioMeh.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (arrowList[arrowIndex] == arrow_down)
            {
                if (arrowIndex == arrowCount - 1)
                {
                    soundEffectPlayer.audioBig.Play();
                    soundEffectPlayer.organ.Play();
                    timeLimit.pitch += 0.2f;
                }
                else
                {
                    player.transform.Translate(2.0f, 0, 0);
                    soundEffectPlayer.audioHit.Play();
                }
                timeLimit.streak++;
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowDGood");
            }
            else
            {
                timeLimit.streak = 0;
                Debug.Log("failedD");
                soundEffectPlayer.audioMeh.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (arrowList[arrowIndex] == arrow_left)
            {
                if (arrowIndex == arrowCount-1)
                {
                    soundEffectPlayer.audioBig.Play();
                    soundEffectPlayer.organ.Play();
                    timeLimit.pitch += 0.2f;
                }
                else
                {
                    player.transform.Translate(2.0f, 0, 0);
                    soundEffectPlayer.audioHit.Play();
                }
                timeLimit.streak++;
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowLGood");
            }
            else
            {
                timeLimit.streak = 0;
                Debug.Log("failedL");
                soundEffectPlayer.audioMeh.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrowList[arrowIndex] == arrow_right)
            {
                if (arrowIndex == arrowCount - 1)
                {
                    soundEffectPlayer.audioBig.Play();
                    soundEffectPlayer.organ.Play();
                    timeLimit.pitch += 0.2f;
                }
                else
                {
                    player.transform.Translate(2.0f, 0, 0);
                    soundEffectPlayer.audioHit.Play();
                }
                timeLimit.streak++;
                Destroy(cloneList[arrowIndex]);
                arrowIndex++;
                Debug.Log("ArrowRGood");
            }
            else
            {
                timeLimit.streak = 0;
                Debug.Log("failedR");
                soundEffectPlayer.audioMeh.Play();
            }
        }
    }
}
