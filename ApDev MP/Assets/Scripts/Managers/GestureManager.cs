using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class GestureManager : MonoBehaviour
{
    public static GestureManager Instance;

    public GameObject barrier;

    public SwipeProperty _swipePropery;
    public EventHandler<SwipeEventArgs> OnSwipe;

    public SpreadProperty _spreadProperty;
    public EventHandler<SpreadEventArgs> OnSpread;


    public Player player;
    private bool activeGesture = false;

    private Vector2 starPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;

    private float gestureTime = 0;

    Touch trackedFinger1;
    Touch trackedFinger2;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (activeGesture)
                return;
            if (Input.touchCount == 1)
            {
                trackedFinger1 = Input.GetTouch(0);

                if (trackedFinger1.phase == TouchPhase.Began)
                {
                    starPoint = trackedFinger1.position;
                    gestureTime = 0;
                }
                else if (trackedFinger1.phase == TouchPhase.Ended)
                {
                    endPoint = trackedFinger1.position;

                    if (gestureTime <= _swipePropery.swipeTime &&
                        Vector2.Distance(starPoint, endPoint) >= (_swipePropery.minSwipeDistance * Screen.dpi))
                    {
                        FireSwipeEvent();
                    }
                }
                else
                {
                    gestureTime += Time.deltaTime;
                }
            }
            else if (Input.touchCount > 1)
            {
                trackedFinger1 = Input.GetTouch(0);
                trackedFinger2 = Input.GetTouch(1);

                if (trackedFinger1.phase == TouchPhase.Moved && trackedFinger2.phase == TouchPhase.Moved)
                {
                    Vector2 prevPoint1 = GetPreviousPoint(trackedFinger1);
                    Vector2 prevPoint2 = GetPreviousPoint(trackedFinger2);

                    Vector2 diffVector = trackedFinger1.position - trackedFinger2.position;
                    Vector2 prevDiffVector = prevPoint1 - prevPoint2;

                    float angle = Vector2.Angle(prevDiffVector, diffVector);

                    float currDistance = Vector2.Distance(trackedFinger1.position, trackedFinger2.position);
                    float prevDistance = Vector2.Distance(prevPoint1, prevPoint2);

                    if (Math.Abs(currDistance - prevDistance) >= (_spreadProperty.minDistanceChange * Screen.dpi))
                    {
                        FireSpreadEvent(currDistance - prevDistance);
                    }
                }
            }
        }
        else
            activeGesture = false;
    }

    private void FireSpreadEvent(float dist)
    {
        if (activeGesture == false)
        {
            if (dist > 0)
            {
                Debug.Log("Spread");
                barrier.SetActive(true);
                activeGesture = true;
            }
            else
            {
                Debug.Log("Pinch");
                barrier.SetActive(false);
                activeGesture = true;
            }
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 direction = endPoint - starPoint;

        SwipeDirections swipeDir = SwipeDirections.RIGHT;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                Debug.Log("right");
                player.QuickSpin(1);
            }
            else
            {
                Debug.Log("left");
                player.QuickSpin(-1);
            }
        }
        activeGesture = true;
        SwipeEventArgs args = new SwipeEventArgs(starPoint, swipeDir, direction);
        if (OnSwipe != null)
        {
            OnSwipe(this, args);
        }
    }

    private Vector2 GetPreviousPoint(Touch finger)
    {
        return finger.position - finger.deltaPosition;
    }
}
