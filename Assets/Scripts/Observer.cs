using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    private bool isPlayerInRange;
    private Vector3 positionPlayer = Vector3.zero;

    public GameEnding gameEnding;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("isInRange");
            isPlayerInRange = true;
            positionPlayer = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            Vector3 direction = positionPlayer - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.localPosition, direction, Color.magenta, 5.0f, true );
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 2f))
            {
               if(raycastHit.transform.CompareTag("Player"))
                {
                    Debug.Log("Tocado");
                   
                }
            }
        }
    }
}
