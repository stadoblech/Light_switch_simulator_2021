using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SwipeDirection
{
    Up,Down
}

public class SwipeController : MonoBehaviour
{
    public delegate void OnSwipeDelegate(SwipeDirection direction);
    public OnSwipeDelegate OnSwipeAction;

    Vector2 startPos;
    Vector2 direction;
    bool directionChosen;

    private void Start()
    {
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            calculateSwipe(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            calculateSwipe(Vector3.down);
        }
#endif

#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            /*
            if (checkForUIUnderSwipe(touch.position))
                return;
            */

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            calculateSwipe(direction);
            directionChosen = false;
        }
#endif

    }

    void calculateSwipe(Vector2 dir)
    { 
        if(dir.y >= 0)
            OnSwipeAction?.Invoke(SwipeDirection.Down);
        else
            OnSwipeAction?.Invoke(SwipeDirection.Up);
    }

    private bool checkForUIUnderSwipe(Vector2 touchPos)
    {
        PointerEventData touch = new PointerEventData(EventSystem.current);
        touch.position = touchPos;
        List<RaycastResult> hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll(touch, hits);
        return (hits.Count > 0); // discard swipe if an UI element is beneath
    }
}
