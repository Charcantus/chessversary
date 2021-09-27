﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AndroidTouch : MonoBehaviour
{
    private Touch oldTouch1; // Last touch point 1 (finger 1)
    private Touch oldTouch2; // Last touch point 2 (finger 2)
    void Update()
    {
                 // No touch, the touch point is 0
        if (Input.touchCount <= 0)
        {
            return;
        }
        // single touch, rotate up and down horizontally
        if (1 == Input.touchCount)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 deltaPos = touch.deltaPosition / 5;
            transform.Rotate(Vector3.down * deltaPos.x, Space.World);//rotate around the Y axis
            transform.Rotate(Vector3.right * deltaPos.y, Space.Self);//rotate around the X axis, below we can also write around the Z axis for rotation
        }
        /*
            //Multiple touch, zoom in and out
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);
        //The second point is just touching the screen, only recording, no processing
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }
                 // Calculate the old two - point distance and the new distance between the two points, become larger to enlarge the model, become smaller to scale the model
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);
                 // The difference between the two distances, positive for the zoom gesture, negative for the zoom gesture
        float offset = newDistance - oldDistance;
                 // Magnification factor, a pixel is calculated by 0.01 times(100 adjustable)
        float scaleFactor = offset / 100f;
        Vector3 localScale = transform.localScale;
        Vector3 scale = new Vector3(localScale.x + scaleFactor,
                                    localScale.y + scaleFactor,
                                    localScale.z + scaleFactor);
                 // Under what circumstances to zoom
        if (scale.x >= 0.5f && scale.y <= 2f)
        {
            transform.localScale = scale;
        }
        //Remember the latest touch point, next time
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
        */
    }
}