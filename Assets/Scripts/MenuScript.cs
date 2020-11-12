using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    Image ear;
    public Sprite on;
    public Sprite off;
    public bool toggled;
    // Start is called before the first frame update
    void Start()
    {
        ear = GameObject.Find("Ear").GetComponent<Image>();
    }

    // Update is called once per frame
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Sound()
    {
        if (toggled)
        {
            ear.sprite = off;
            toggled = false;
        }
        else
        {
            ear.sprite = on;
            toggled = true;
        }
    }
}
