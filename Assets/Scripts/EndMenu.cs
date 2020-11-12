using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    Scene scene;
    public int level;

    public void Quit()
    {
        SceneManager.LoadScene(0);
        
    }
    public void Progress()
    {
        switch (level)
        {
            case 1:
                SceneManager.LoadScene(2);
                Debug.Log(scene.buildIndex);
                break;
            case 2:
                SceneManager.LoadScene(3);
                Debug.Log(scene.buildIndex);
                break;
            case 0610:
                SceneManager.LoadScene(4);
                break;
                
        }
        
     
    }
}
