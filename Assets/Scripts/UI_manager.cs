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
    public TextMeshProUGUI startText;
    public GameObject correct;
    public GameObject inCorrect;
    public int answer;
    public int answered;
    public int Level;
    public bool endState;

    public GameObject icon1;
    public GameObject icon2;
    public GameObject icon3;

    

    public Image life1;
    public Image life2;
    public Image life3;
    public Sprite halfHeart;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool go;
    public int score;
    public int numLives = 6;
    public int multiplier;
    public bool timeOn;
    public float timeLeft;

    public GameObject timer;
    public Image timerWheel;
    public float maxTime = 10f;


    public GameObject Qcanvas;
    public GameObject Gcanvas;
    public GameObject Ecanvas;
    public GameObject Acanvas;
    public GameObject Rcanvas;
    public GameObject Scanvas;

    private IEnumerator RemoveAfterSeconds;


    public UtilityBehaviors util;
    public LevelGeneration lg;

    void endGame()
    {
        Acanvas.SetActive(false);
        endState = true;
        Gcanvas.SetActive(false);
        theCamera.transform.Translate(0, 0, -1);

        if (score < 10)
        {
            finish.SetText(@"¯\_(ツ)_/¯");
        }
        else if (score < 40)
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
        setGo(false);
        Debug.Log("set go to "+go);


        var uiObjects = GetComponentsInChildren<TextMeshProUGUI>();
        string newQuestion;
        int first;
        int second;
        int index = Random.Range(1, 3);
        List<int> buttons = new List<int> { 0, 1, 2 };
        int opChance = Random.Range(0, 100);

        switch (Level)
        {
            case 1:
                //Generate question outta 2 random nums
                first = Random.Range(0, 10);
                second = Random.Range(0, 10);

                //Write it dooown
                newQuestion = (first.ToString() + " + " + second.ToString());
                uiObjects[3].SetText("What is " + newQuestion + "?");
                answer = first + second;

                buttons.Remove(index);
                uiObjects[index].SetText(answer.ToString());

                foreach (int button in buttons)
                {
                    uiObjects[button].SetText((Random.Range(0, 20).ToString()));

                }
                break;

            case 2:
                //Generate question outta 2 random nums
                first = Random.Range(0, 30);
                second = Random.Range(0, 30);

                

                if(opChance > 49)
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " + " + second.ToString());
                    answer = first + second;
                }
                else
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " - " + second.ToString());
                    answer = first - second;
                }

                uiObjects[3].SetText("What is " + newQuestion + "?");
                buttons.Remove(index);
                uiObjects[index].SetText(answer.ToString());

                foreach (int button in buttons)
                {
                    uiObjects[button].SetText((Random.Range(0, 60).ToString()));

                }
                break;
            case 3:
                //Generate question outta 2 random nums
                first = Random.Range(0, 30);
                second = Random.Range(0, 30);



                if (opChance <= 30)
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " + " + second.ToString());
                    answer = first + second;
                }
                else if (opChance <= 60)
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " - " + second.ToString());
                    answer = first - second;
                }
                else
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " x " + second.ToString());
                    answer = first * second;
                }

                uiObjects[3].SetText("What is " + newQuestion + "?");
                buttons.Remove(index);
                uiObjects[index].SetText(answer.ToString());

                foreach (int button in buttons)
                {
                    uiObjects[button].SetText((Random.Range(0, 100000).ToString()));

                }
                break;
            case 4:
                //Generate question outta 2 random nums
                first = Random.Range(0, 50);
                second = Random.Range(0, 50);



                if (opChance <= 30)
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " + " + second.ToString());
                    answer = first + second;
                }
                else if (opChance <= 60)
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " - " + second.ToString());
                    answer = first - second;
                }
                else
                {
                    //Write it dooown
                    newQuestion = (first.ToString() + " x " + second.ToString());
                    answer = first * second;
                }

                uiObjects[3].SetText("What is " + newQuestion + "?");
                buttons.Remove(index);
                uiObjects[index].SetText(answer.ToString());

                foreach (int button in buttons)
                {
                    uiObjects[button].SetText((Random.Range(0, 100000).ToString()));

                }
                break;
            default:
                Debug.Log("summink wron wit levl");
                break;

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


    void deductLife()
    {
        switch (numLives)
        {
            case 1:
                Debug.Log("0 Lives left");
                numLives = 0;
                endGame();
                break;
            case 2:
                Debug.Log("1 Life left");
                numLives = 1;
                life1.sprite = halfHeart;
                break;
            case 3:
                Debug.Log("2 Lives left");
                numLives = 2;
                life2.sprite = emptyHeart;
                break;
            case 4:
                Debug.Log("3 Lives left");
                numLives = 3;
                life2.sprite = halfHeart;
                break;
            case 5:
                Debug.Log("4 Lives left");
                numLives = 4;
                life3.sprite = emptyHeart;
                break;
            case 6:
                Debug.Log("5 Lives left");
                numLives = 5;
                life3.sprite = halfHeart;

                break;
            default:
                Debug.Log("Summink Wrong!");
                break;




        }
    }

    void Checkanswer()
    {

        if (answered == 1)
        {
            score += (Mathf.RoundToInt(timeLeft)*multiplier);
            scoreText.SetText("Score:" + score);
            correct.SetActive(true);


            setGo(true);
            timeOn = false;

        } 
        else if (answered == 2)
        {
            Debug.Log("Incorrect Answer.");
            inCorrect.SetActive(true);
            deductLife();
            setGo(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
        util = GameObject.Find("Manager").GetComponent<UtilityBehaviors>();
        lg = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
        Qcanvas = GameObject.Find("QuestionCanvas");
        Gcanvas = GameObject.Find("GameplayCanvas");
        Ecanvas = GameObject.Find("EndCanvas");
        Acanvas = GameObject.Find("AnsweredCanvas");
        Rcanvas = GameObject.Find("ResultCanvas");
        Scanvas = GameObject.Find("StartCanvas");

        finish = GameObject.Find("FinishText").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        startText = GameObject.Find("StartText").GetComponent<TextMeshProUGUI>();
        correct = GameObject.Find("Correct");
        inCorrect = GameObject.Find("Incorrect");
        correct.SetActive(false);
        inCorrect.SetActive(false);
        timer = GameObject.Find("timerWheel");
        timerWheel = timer.GetComponent<Image>();

        icon1 = GameObject.Find("Life 1");
        icon2 = GameObject.Find("Life 2");
        icon3 = GameObject.Find("Life 3");
        life1 = icon1.GetComponent<Image>();
        life2 = icon2.GetComponent<Image>();
        life3 = icon3.GetComponent<Image>();


        Qcanvas.SetActive(false);
        Ecanvas.SetActive(false);
        Acanvas.SetActive(false);
        Scanvas.SetActive(true);


        timeLeft = maxTime;

        go = true;
        answered = 0;
        scoreText.SetText("Score: 0");

        switch (Level)
        {
            case 1:
                startText.SetText("LEVEL 1");
                break;
            case 2:
                startText.SetText("LEVEL 2");
                break;
            case 3:
                startText.SetText("LEVEL 3");
                break;
            case 4:
                startText.SetText("HARDCORE MODE!");
                break;
        }
        


    }

    public void resetTime()
    {
        timeLeft = maxTime;
    }

    public void RoomEnter()
    {
        correct.SetActive(false);
        inCorrect.SetActive(false);
        Scanvas.SetActive(false);

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
        else if (endState)
        {
            Acanvas.SetActive(false);
            Debug.Log("GameOVer");
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
                timeOn = false;
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
