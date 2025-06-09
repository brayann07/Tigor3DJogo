using System.Collections;
using UnityEngine;

public class PlayerAndar : MonoBehaviour
{
    public float Speed = 5f;
    public float RotSpeed = 250f;
    private float Rotation;
    public float Gravity = 5f;
    private float verticalVelocity;
    Vector3 MoveDirection;
    CharacterController controller;
    Animator anim;
    public int auxiliar = 0;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                MoveDirection = Vector3.forward * (3.0f * Speed);
                anim.SetInteger("aux", 2);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                MoveDirection = Vector3.forward * Speed;
                anim.SetInteger("aux", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveDirection = Vector3.back * Speed;
                anim.SetInteger("aux", 1);
            }
            else
            {
                if (auxiliar == 0)
                {
                    MoveDirection = Vector3.zero;
                    anim.SetInteger("aux", 0);
                }
            }
            if(auxiliar == 1)
            {
                anim.SetInteger("aux", 3);
                StartCoroutine(Cooldown());
            }
            MoveDirection = transform.TransformDirection(MoveDirection);
        }

        // Rotação
        float horizontalInput = Input.GetAxis("Horizontal");
        Rotation += horizontalInput * RotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, Rotation, 0);

        // Gravidade
        MoveDirection.y -= Gravity * Time.deltaTime;

        controller.Move(MoveDirection * Time.deltaTime);
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(6f);
        auxiliar = 0;
    }
}
