using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_manager : MonoBehaviour
{

    public Camera theCamera;
    public TextMeshPro question;
    public TextMeshProUGUI finish;
    public TextMeshProUGUI scoreText;
    public int answer;
    public int answered;

    public bool go;
    public int score;
    public bool timeOn;
    public float timeLeft;

    public Image timerWheel;
    public float maxTime = 10f;


    public GameObject Qcanvas;
    public GameObject Gcanvas;
    public GameObject Ecanvas;
    public GameObject Acanvas;

    public UtilityBehaviors util;
    public LevelGeneration lg;

    void endGame()
    {
        Gcanvas.SetActive(false);
        theCamera.transform.Translate(0, 0, -1);

        if (score < 3)
        {
            finish.SetText(@"¯\_(ツ)_/¯");
        }
        else if (score < 6)
        {
            finish.SetText("You did pretty good!");
        }
        else
        {
            finish.SetText("Congratulations!");
        }

        theCamera.orthographicSize = 50f;
        Ecanvas.SetActive(true);


    }


    void GenerateQuestion()
    {
        
        Qcanvas.SetActive(true);
        resetTime();
        timeOn = true;
        //7setGo(false);
        Debug.Log("set go to "+go);
        var uiObjects = GetComponentsInChildren<TextMeshProUGUI>();
        int first = Random.Range(0, 10);
        int second = Random.Range(0, 10);
        string newQuestion = (first.ToString() + " + " + second.ToString());
        uiObjects[3].SetText(newQuestion);
        answer = first + second;

        List<int> buttons = new List<int> { 0, 1, 2 };
        int index = Random.Range(1, 3);
        buttons.Remove(index);
        uiObjects[index].SetText(answer.ToString());

        foreach(int button in buttons)
        {
            uiObjects[button].SetText((Random.Range(0, 20).ToString()));
        
        }
    }

    

    public bool getGo()
    {
        return go;
    }

    public void setGo(bool boolean)
    {
        go = boolean;
    }

    void Checkanswer()
    {

        if (answered == 1)
        {
            score += 1;
            scoreText.SetText("Score:" + score);
            Debug.Log("Correct Answer, score now: "+score);
            setGo(true);
            timeOn = false;

        } 
        else if (answered == 2)
        {
            Debug.Log("Incorrect Answer.");
            setGo(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        util = GameObject.Find("Manager").GetComponent<UtilityBehaviors>();
        lg = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
        Qcanvas = GameObject.Find("QuestionCanvas");
        Gcanvas = GameObject.Find("GameplayCanvas");
        Ecanvas = GameObject.Find("EndCanvas");
        Acanvas = GameObject.Find("AnsweredCanvas");

        finish = GameObject.Find("FinishText").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        Qcanvas.SetActive(false);
        Ecanvas.SetActive(false);
        Acanvas.SetActive(false);

        timerWheel = GameObject.Find("Image").GetComponent<Image>();
        timeLeft = maxTime;

        go = true;
        answered = 0;
        scoreText.SetText("Score: 0");

        


    }

    public void resetTime()
    {
        timeLeft = maxTime;
    }

    public void RoomEnter()
    {
        
        //Debug.Log("entered room");
        if (util.usedRooms.Contains(util.currentPosition))
        {
            Qcanvas.SetActive(false);
            Acanvas.SetActive(true);
            Debug.Log("Already answered");

        }
        else if(util.currentPosition == util.StartPoint)
        {
            Qcanvas.SetActive(false);
            Debug.Log("Start Point!");
        }
        else
        {
            Acanvas.SetActive(false);
            GenerateQuestion();
        }
        
        //int count = 0;

        //foreach(Vector2 room in util.usedRooms)
        //{
        //    if(util.currentPosition == room)
        //    {
                
        //        Debug.Log("Already answered");
        //    }
        //    if(count == util.usedRooms.Count)
        //    {
        //        GenerateQuestion();

        //        break;
        //    }
        //    else
        //    {
        //        count = count + 1;
        //    }
        //}
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerWheel.fillAmount = timeLeft / maxTime;
            }
            else
            {
                answered = 2;
            }
        }
        if (answered != 0 )
        {
            Checkanswer();
            Qcanvas.SetActive(false);
            util.usedRooms.Add(util.currentPosition);
            answered = 0;
        }
        if((util.usedRooms.Count+1) == lg.numberOfRooms)
        {
            Debug.Log("All Questions Done!");
            endGame();
        }
        


    }
}
