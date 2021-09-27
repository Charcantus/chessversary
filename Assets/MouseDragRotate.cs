using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MouseDragRotate : MonoBehaviour
{
     public Transform target;
     public float maxOffsetDistance = 2000f;
     public float orbitSpeed = 15f;
     public float panSpeed = .5f;
     public float zoomSpeed = 10f;
     private Vector3 targetOffset = Vector3.zero;
     private Vector3 targetPosition;
     public float minDist;
     public float maxDist;

     void Update()
     {
         targetPosition = target.position + targetOffset;

         if (target != null)
         {
             targetPosition = target.position + targetOffset;

             // Left Mouse to Orbit
             if (Input.GetMouseButton(0))
             {
                 float pitchAngle = Vector3.Angle(Vector3.up, transform.forward);
                 float pitchDelta = -Input.GetAxis("Mouse Y") * orbitSpeed;
                 float newAngle = Mathf.Clamp(pitchAngle + pitchDelta, 0f, 180f);
                 //pitchDelta = newAngle - pitchAngle;
                 transform.RotateAround(targetPosition, Vector3.up, Input.GetAxis("Mouse X") * orbitSpeed);
                 transform.RotateAround(targetPosition, transform.right, pitchDelta);
             }
         }
     }

}