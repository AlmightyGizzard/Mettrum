using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class EndMenu : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene scene;

    public void Quit()
    {
        
        
    }
    public void Progress()
    {
        EditorSceneManager.LoadScene(scene.buildIndex+1);

    }
}
