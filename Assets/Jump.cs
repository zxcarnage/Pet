using System.Collections;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Transform targetPoint;
    public Vector3 xMovementVector = Vector3.zero; // Vector to move along X axis
    public float jumpHeight = 5.0f;
    public float timeToReachTarget = 1.0f;
    public AnimationCurve jumpCurve;

    private void Start()
    {
        StartCoroutine(JumpToTarget());
    }

    private IEnumerator JumpToTarget()
    {
        Vector3 initialPosition = transform.position;
        Vector3 toTarget = targetPoint.position - initialPosition;

        float horizontalDistance = new Vector3(toTarget.x, 0, toTarget.z).magnitude;

        float timeElapsed = 0;

        while (timeElapsed <= timeToReachTarget)
        {
            float normalizedTime = timeElapsed / timeToReachTarget;
            float verticalDistance = jumpCurve.Evaluate(normalizedTime) * jumpHeight;
            float horizontalDistanceAtTime = normalizedTime * horizontalDistance;

            Vector3 newPosition = initialPosition + toTarget.normalized * horizontalDistanceAtTime;
            newPosition.y = initialPosition.y + verticalDistance;
            newPosition += xMovementVector * normalizedTime;

            transform.position = newPosition;

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Vector3 finalPosition = initialPosition + toTarget;
        finalPosition.y = targetPoint.position.y;
        finalPosition += xMovementVector;
        transform.position = finalPosition;
    }
}

