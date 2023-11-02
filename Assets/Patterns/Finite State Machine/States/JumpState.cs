using UnityEngine;

[CreateAssetMenu(menuName = "States/Character/Jump")]
public class JumpState : State<CharacterStateMachine>
{
    private GroundCheck _groundCheck;
    private Rigidbody _rigidbody;
    private bool _leftGround;

    [SerializeField] private float _jumpVelocity;

    public override void Init(CharacterStateMachine parent)
    {
        base.Init(parent);
        if (_groundCheck == null) _groundCheck = parent.GetComponent<GroundCheck>();
        if (_rigidbody == null) _rigidbody = parent.GetComponent<Rigidbody>();
        _leftGround = false;
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpVelocity, _rigidbody.velocity.z);
    }

    public override void CaptureInput()
    {
        
    }

    public override void Update()
    {
        if (!_groundCheck.IsGrounded())
            _leftGround = true;
    }

    public override void FixedUpdate()
    {
        
    }

    public override void ChangeState()
    {
        if(_leftGround && _groundCheck.IsGrounded())
            _runner.SetState(typeof(MoveState));
    }

    public override void Exit()
    {
        
    }
}
