using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private float _angularSpeed;
    private float _rotationAngle;
    private float _speed;
    private CharacterController _character;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 0f;
        _rotationAngle = 0f;
        _angularSpeed = 5f;
        _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))    // while W key is pushed
        {
            while (_speed < 20f)    // increase velocity gradually
            {
                _speed += 5f;
            }
            _speed = 20f;   // max velocity
        }

        else // W key is not pushed
        {   
            while (_speed > 0f) // dicrease velocity
            {
                _speed -= 5f;
            }
            _speed = 0f;    // stop
        }

        //Sets sight firection by means of transform.Rotate
        _rotationAngle += mouse_x * _angularSpeed * Time.deltaTime;
        //transform.Rotate(new Vector3(0, _rotationAngle, 0));
        transform.Rotate(0, _rotationAngle, 0);

        //Translate is one of transformatioins that uses Vector3
        //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
      
        //We shall use CharacterController to move and to stop if camera collides with another object
        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        _character.Move(direction);
    }
}
