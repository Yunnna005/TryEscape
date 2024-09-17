using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonController : MonoBehaviour
{
    public float detectionRadius = 10f;
    MeshRenderer meshRenderer;
    private float timeRemaining = 0;
    private bool isPressed = false;

    void OnMouseDown()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        isPressed = true;
        timeRemaining = 10f;
        ChangeButtonColor(meshRenderer);
        OpenNearestDoor();
    }

    private void Update()
    {
        if (isPressed)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            if (timeRemaining <= 0)
            {
                isPressed = false;
                ChangeButtonColor(meshRenderer);
            }
        }
    }

    private void ChangeButtonColor(MeshRenderer mr)
    {
        if (isPressed)
        {
            mr.material.color = Color.green;
        }
        else
        {
            mr.material.color = Color.white;
        }
    }

    void OpenNearestDoor()
    {
        DoorController[] allDoors = FindObjectsOfType<DoorController>();
        DoorController nearestDoor = null;
        float minDistance = Mathf.Infinity;

        foreach (DoorController door in allDoors)
        {
            float distance = Vector3.Distance(transform.position, door.transform.position);

            if (distance < minDistance && distance <= detectionRadius)
            {
                minDistance = distance;
                nearestDoor = door;
            }
        }

        if (nearestDoor != null)
        {
            nearestDoor.OpenDoor();
        }
        else
        {
            Debug.LogWarning("No door found within the detection radius!");
        }
    }
}
