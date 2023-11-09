using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    private Vector3 _moveVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        _moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("isRunning", true);
        }
        else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            animator.SetBool("isRunning", false);
        }
        
        _rigidbody.MovePosition(_rigidbody.position + _moveVector);
    }
}
