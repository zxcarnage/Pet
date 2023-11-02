using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Vector3 _groundBoxSize;
    [SerializeField] private LayerMask _mask;
    
    public bool IsGrounded()
    {
        Physics.BoxCast(transform.position, _groundBoxSize, Vector3.down, out RaycastHit hit);
        return hit.transform.gameObject.layer == _mask;
    }
}
