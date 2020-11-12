using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    None = 0,
    Up = 1,
    Down = 2,
    Left = 4,
    Right = 8

}

public class SwipeManager : MonoBehaviour
{
    private static SwipeManager instance;
    public static SwipeManager Instance { get { return instance; } }

    

    public SwipeDirection Direction { set; get; }

    private Vector3 touchPosition;
    public float swipeResistanceX = 50.0f;
    public float swipeResistanceY = 100.0f;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        Direction = SwipeDirection.None;

        if (Input.GetMouseButtonDown(0)) 
        {
            touchPosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            Vector2 deltaSwipe = touchPosition - Input.mousePosition;

            if(Mathf.Abs (deltaSwipe.x) > swipeResistanceX)
            {
                // Swipe on the X axis
                Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;

            }

            else if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
            {
                // Swipe on the Y axis
                Direction |= (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;
            }
        }


    }

    public bool IsSwiping(SwipeDirection dir)
    {
       return (Direction & dir) == dir;
    }
}
