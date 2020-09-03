using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    float speed;
    float angularSpeed;
    float horizontalMove;
    float verticalMove;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        angularSpeed = 40f;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            horizontalMove = Input.GetAxis("Horizontal") * angularSpeed * Time.deltaTime;   // -1 for left and 1 for right if was pressed
            verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;    // -1 back and 1 forward if was pressed

            if(verticalMove!=0)
            {
                GetComponent<Animation>().Play("Female Walk");
            }
            transform.Rotate(0, horizontalMove, 0); // walk through rotation

            // stay at terrains height
            //Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            //Vector3 point;
            //point.y = Terrain.activeTerrain.SampleHeight(pos) - transform.position.y;
            Vector3 direction = Vector3.forward * verticalMove;
            //direction.y = point.y;

            //transform.Translate(Vector3.forward*verticalMove);  // walk forward/backward
            // TransformDirection translates (transforms) coordinates to globals
            controller.Move(transform.TransformDirection(direction));
        }
        
        else
        {
            // if no arrows key pressed, animate idle
            GetComponent<Animation>().Play("Idle");
        }
    }
}
