using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonController : MonoBehaviour
{
    public float detectionRadius = 10f; 

    void OnMouseDown()
    {
        OpenNearestDoor();
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
