using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    public Animator animator;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");    // set trigger to open
        isOpen = true;
    }

    public void CloseDoor()
    {
        if (isOpen)
        {
            animator.SetTrigger("Close");
            isOpen = false;
        }
    }
}
