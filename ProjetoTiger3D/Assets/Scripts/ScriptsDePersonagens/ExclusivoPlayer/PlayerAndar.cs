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

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        PlantarPlanta();
    }

    void Update()
    {
        Move();

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }
    }

    void Move()
    {
        bool isMovingForward = Input.GetKey(KeyCode.W);
        bool isMovingBackward = Input.GetKey(KeyCode.S);
        bool isRunning = isMovingForward && Input.GetKey(KeyCode.LeftShift);

        if (controller.isGrounded)
        {
            if (isRunning)
            {
                MoveDirection = Vector3.forward * (3.0f * Speed);
                anim.SetBool("IsIdle", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("IsRunning", true);

            }
            else if (isMovingForward)
            {
                MoveDirection = Vector3.forward * Speed;
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("isWalking", true);
            }
            else if (isMovingBackward)
            {
            MoveDirection = -Vector3.forward * Speed;
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("isWalking", true); // Usa mesma animação de andar
            }
            else
            {
                MoveDirection = Vector3.zero;
                anim.SetBool("IsIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("IsRunning", false);
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
    public void PlantarPlanta()
    {
        if (anim != null)
        {
            Debug.Log("ele ta plantando");
            anim.SetTrigger("plantando");
        }
        else
        {
            Debug.LogError("anim ta nula no tiger por algum motivo");
        }
    }
}
