using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilityBehaviors : MonoBehaviour {

    public GameObject theCamera;
    public Vector2 camPos;
    public float CameraSpeed;

    public Vector2 StartPoint = new Vector2(0, 0);
    public Vector2 currentPosition = new Vector2(0, 0);
    public List<Vector2> CameraPoints;
    public List<Vector2> usedRooms = new List<Vector2>();
    public int NoofRooms;

    float step;
    
    public UI_manager ui;
    public LevelGeneration lg;

    public void Start()
    {
        ui = GameObject.Find("Manager").GetComponent<UI_manager>();
        lg = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>();
        CameraPoints = GameObject.Find("LevelGenerator").GetComponent<LevelGeneration>().CameraPoints;
        int NoofRooms = lg.numberOfRooms;
        
        camPos = new Vector2(theCamera.transform.position.x, theCamera.transform.position.y);


    }


    bool IsWall(Vector2 position)
    {
        int count = 0;
        foreach(Vector2 item in CameraPoints)
        {
            if (position == item)
            {
                return true;
                
            }
            else
            {
                count += 1;
            }
            if (count == NoofRooms)
            {
                break;
            }
        }
        return false;
        
    }

    void Update () {

        step = CameraSpeed * Time.deltaTime;

        //GameObject.Find("Manager").GetComponent<UI_manager>();
        if (ui.getGo() && SwipeManager.Instance.IsSwiping(SwipeDirection.Left)) //If Swiping left...
        {
            Vector2 newPosition = new Vector2(currentPosition.x + 16, currentPosition.y); //Look up the area to the right.
            if (IsWall(newPosition)) //Is there a room there?
            {
                theCamera.transform.Translate(16, 0, 0);//If so, move the camera to the right, centring on that room. 

                currentPosition.x = (currentPosition.x + 16);//Update our current position.
                ui.RoomEnter();
                
                
            }
            else
            {
                Debug.Log("Can't go there!");//If not, display an error in debug (will add in-game error later)
            }
            
        }
        if (ui.getGo() && SwipeManager.Instance.IsSwiping(SwipeDirection.Right)) //If Swiping right...
        {
            Vector3 newPosition = new Vector3(currentPosition.x - 16, currentPosition.y, -1);
            if (IsWall(newPosition))//Is there a room there?
            {
                theCamera.transform.Translate(-16, 0, 0);//If so, move the camera to the left, centring on that room. 


                //Vector3 newPos = new Vector3(newPosition.x, newPosition.y, -1);
                //theCamera.transform.position = Vector3.Lerp(theCamera.transform.position, newPos, Time.deltaTime * CameraSpeed);

                //theCamera.transform.position = Vector3.MoveTowards(theCamera.transform.position, newPosition, 10f * Time.deltaTime);
               
                currentPosition.x = (currentPosition.x - 16);//Update our current position.
                ui.RoomEnter();
            }
            else
            {
                Debug.Log("Can't go there!");//If not, display an error in debug (will add in-game error later)
            }
        }
        if (ui.getGo() && SwipeManager.Instance.IsSwiping(SwipeDirection.Up)) //If Swiping up...
        {
            Vector2 newPosition = new Vector2(currentPosition.x, currentPosition.y - 8);
            if (IsWall(newPosition))//Is there a room there?
            {
                theCamera.transform.Translate(0, -8, 0);//If so, move the camera downward, centring on that room. 
                currentPosition.y = (currentPosition.y - 8);//Update our current position.
                ui.RoomEnter();
            }
            else
            {
                Debug.Log("Can't go there!");//If not, display an error in debug (will add in-game error later)
            }
        }
        if (ui.getGo() && SwipeManager.Instance.IsSwiping(SwipeDirection.Down))  //If Swiping down...
        {
            Vector2 newPosition = new Vector2(currentPosition.x, currentPosition.y + 8);
            if (IsWall(newPosition))//Is there a room there?
            {
                theCamera.transform.Translate(0, 8, 0);//If so, move the camera upward, centring on that room. 
                currentPosition.y = (currentPosition.y + 8);//Update our current position.
                ui.RoomEnter();
            }
            else
            {
                Debug.Log("Can't go there!");//If not, display an error in debug (will add in-game error later)
            }
        }




    }
}
