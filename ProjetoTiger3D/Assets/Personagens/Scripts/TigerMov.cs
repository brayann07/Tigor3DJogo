using Unity.VisualScripting;
using UnityEngine;

public class TigerMov : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    private float Rotation;
    public float Gravity;

    Vector3 MoveDirection;
    CharacterController controller;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {

            if (Input.GetKey(KeyCode.W))
            {
                MoveDirection = Vector3.forward * Speed;
                MoveDirection = transform.TransformDirection(MoveDirection);
                anim.SetInteger("transitions", 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                MoveDirection = Vector3.back * Speed;
                MoveDirection = transform.TransformDirection(MoveDirection);
                anim.SetInteger("transitions", 1);
            }
            
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                MoveDirection = Vector3.forward * (3.0f * Speed);
                MoveDirection = transform.TransformDirection(MoveDirection);
                anim.SetInteger("transitions", 2);
            }
            if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.LeftShift))
            {
                MoveDirection = Vector3.zero;
                anim.SetInteger("transitions", 0);
                
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) 
            {
                MoveDirection = Vector3.zero;
                anim.SetInteger("transitions", 0);
              
            }
        }
        Rotation += Input.GetAxis("Horizontal") * RotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, Rotation, 0);
       

        MoveDirection.y -= Gravity * Time.deltaTime;
        controller.Move(MoveDirection * Time.deltaTime);
    }

}
