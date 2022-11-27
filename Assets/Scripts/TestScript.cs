using Asteroids.InputModule;
using Asteroids.Infrastructure;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestScript : MonoBehaviour, Asteroids.Infrastructure.IObserver<InputArgs>
{
    [SerializeField] private InputEvent inputEvent;

    private Rigidbody _rigidbody;
    
    private Vector3 _moveDirection = Vector3.zero;
    private const float MoveSpeed = 5.00f;
    private float _rotateSide = 0.00f; // left -1, right 1
    private const int RotateAngle = 5;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputEvent.Attach(this);
    }

    private void OnDisable()
    {
        inputEvent.Detach(this);
    }
    
    private void FixedUpdate()
    {
        if (_moveDirection != Vector3.zero)
        {
            var directions = GetMovement(_rigidbody);
            _rigidbody.AddForce(directions.horizontal * Time.fixedDeltaTime, ForceMode.VelocityChange);
            _rigidbody.AddForce(directions.vetrical * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        if (_rotateSide != 0)
        {
            var rotate = GetRotate(0.05f);
            _rigidbody.AddRelativeTorque(rotate, ForceMode.VelocityChange);
        }
    }

    public void OnEventRaised(ISubject<InputArgs> subject, InputArgs args)
    {
        _moveDirection = new Vector3(args.MovingDestination.normalized.x, 0, args.MovingDestination.normalized.y);
        _rotateSide = -args.RotationSide;
    }

    private (Vector3 horizontal, Vector3 vetrical) GetMovement(Component rb)
    {
        var horizontal = Vector3.zero;
        var yertical = Vector3.zero;
        
        switch (_moveDirection.x)
        {
            case > 0: 
                horizontal = rb.transform.right * MoveSpeed;
                break;
            case < 0: 
                horizontal = -rb.transform.right * MoveSpeed;
                break;
        }
            
        switch (_moveDirection.z)
        {
            case > 0: 
                yertical = rb.transform.forward * MoveSpeed;
                break;
            case < 0: 
                yertical = -rb.transform.forward * MoveSpeed;
                break;
        }

        return (horizontal, yertical);
    }

    private Vector3 GetRotate(float step)
    {
        switch (_rotateSide) 
        {
            case 1:
                return new Vector3(0, -step, 0);
            case -1:
                return new Vector3(0, step, 0);
            default:
                return Vector3.zero;
        }
    }
}