using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Movement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction moveAction;
    [SerializeField] float speed = 5f;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        MovePlayer();    
    }

    void MovePlayer()
    {
        var direction = moveAction.ReadValue<Vector2>();
        var movement = new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
        transform.position += movement;
    }
}
