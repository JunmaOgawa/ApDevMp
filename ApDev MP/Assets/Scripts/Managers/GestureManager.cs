using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
public class GestureManager : MonoBehaviour
{
    public SwipeProperty _swipePropery;

    public static GestureManager Instance;

    public TapProperty _tapProperty;

    private Vector2 starPoint = Vector2.zero;
    private Vector2 endPoint = Vector2.zero;

    private float gestureTime = 0;

    Touch trackedFinger1;

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
        if(Input.touchCount > 0)
        {
            trackedFinger1 = Input.GetTouch(0);

            if(trackedFinger1.phase == TouchPhase.Began)
            {
                starPoint = trackedFinger1.position;
                gestureTime = 0;
            }
            else if(trackedFinger1.phase == TouchPhase.Ended)
            {
                endPoint = trackedFinger1.position;
            }
            else
            {
                gestureTime += Time.deltaTime;
            }
        }
    }
}
