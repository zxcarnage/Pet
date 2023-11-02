using UnityEngine;

[CreateAssetMenu(menuName = "States/Character/Move")]
public class MoveState : State<CharacterStateMachine>
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;
    private GroundCheck _groundCheck;

    private Vector3 _movementVector;

    private bool _jumpPressed;
    public override void Init(CharacterStateMachine parent)
    {
        base.Init(parent);
        if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody>();
        if (_groundCheck == null) _groundCheck = parent.GetComponent<GroundCheck>();
    }

    public override void CaptureInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _movementVector = new Vector3(horizontal, 0, vertical);
        _jumpPressed = Input.GetButtonDown("Jump");
    }

    public override void Update()
    {
        
    }

    public override void FixedUpdate()
    {
        _rigidbody.velocity = _movementVector * _speed;
    }

    public override void ChangeState()
    {
        if (_groundCheck.IsGrounded() && _jumpPressed)
        {
            _runner.SetState(typeof(JumpState));
        }
    }

    public override void Exit()
    {
        
    }
}
