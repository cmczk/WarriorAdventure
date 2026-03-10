using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    Animator animator;
    InputAction moveAction;
    [SerializeField] float speed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();    
    }

    void MovePlayer()
    {
        var direction = moveAction.ReadValue<Vector2>();
        var movement = speed * Time.deltaTime * new Vector3(direction.x, direction.y);
        transform.position += movement;

        var targetAngle = transform.rotation.eulerAngles.y;

        if (movement.x < 0f)
        {
            targetAngle = -90f;
        }
        else if (movement.x > 0f)
        {
            targetAngle = 90f;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, targetAngle, 0), Time.deltaTime * 15f);

        if (movement == Vector3.zero)
        {
            animator.SetFloat("Speed", 0f, 0.01f, Time.deltaTime);
        }
        else if (moveAction.IsPressed())
        {
            animator.SetFloat("Speed", 0.4f, 0.01f, Time.deltaTime);
        }
    }
}
