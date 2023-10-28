
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterkompleks : MonoBehaviour

{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;



    // gravitasi dan deteksi nempel tanah / ground
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    // lompat
    [SerializeField] private float jumpHeight;

    private CharacterController controller;


    private Animator anim;





    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150;

        transform.Rotate(0, x, 0);
        Move();
    }


    private void Move()
    {


        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ);
        //moveDirection *= walkSpeed;
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }

            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }

            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;



            if (Input.GetKeyDown(KeyCode.Space))
            {

                Jump();
            }
        }


        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }






    private void Idle()
    {
        moveSpeed = 0;
        anim.SetTrigger("diam");
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetTrigger("jalan");
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetTrigger("lari");
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetTrigger("diam");
    }




}