using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        SetInitialState();
    }

    void SetInitialState()
    {
        animator.Play("Doors Idle");
    }

    public void OpenDoor()
    {
        // Trigger the combined animation
        animator.SetTrigger("DoorsOpenClose");
    }
}
