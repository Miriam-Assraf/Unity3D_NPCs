using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentsBathroomDoorTrigger : MonoBehaviour
{
    private DoorMotion doorMotion;

    // Start is called before the first frame update
    void Start()
    {
        doorMotion = GameObject.Find("Parents Bathroom Door Axis").GetComponent<DoorMotion>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("NPC")) // if main camera enters collider
        {
            doorMotion.OpenDoor();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        doorMotion.CloseDoor();
    }

}
