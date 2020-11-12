using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IsCorrect : MonoBehaviour
{
    public bool answered;

    public void Click()
    {
        Debug.Log("Reached here");
        var someRandomVariable = GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log("Reached here2");
        string answer = GameObject.Find("Manager").GetComponent<UI_manager>().answer.ToString();
        string text = someRandomVariable.text;
        var UI_Controller = GameObject.Find("Manager").GetComponent<UI_manager>();
        if (text == answer)
        {
            //return true;
            Debug.Log("C");
            UI_Controller.answered = 1;
        }
        else
        {

            //return false;
            Debug.Log("I");
            UI_Controller.answered = 2;

        }
    }
}