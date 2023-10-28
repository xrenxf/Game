using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    public float speed = 12f;
    public CharacterController karakter;
    public float gr = -9.81f;
    Vector3 velocity;
    public FixedJoystick joystik;

    // Update is called once per frame
    private void Start()
    {


    }
    void Update()
    {

        //IMPLEMENTASIKAN JOYSTICK
        float x = joystik.Horizontal;
        float z = joystik.Vertical;

        //UNTUK MENNGERAKAN player
        Vector3 move = transform.right * x + transform.forward * z;
        karakter.Move(move * speed * Time.deltaTime);

        //MEMBUAT GRAVITASI
        velocity.y += gr * Time.deltaTime;
        karakter.Move(velocity * Time.deltaTime);



    }



}
