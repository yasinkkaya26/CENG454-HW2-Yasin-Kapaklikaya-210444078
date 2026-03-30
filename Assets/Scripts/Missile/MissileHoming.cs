using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
    [SerializeField] private float turningSpeed = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target == null) 
        return;

        Vector3 directionToTarget = (target.position - transform.position).normalized;

        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                turningSpeed * Time.deltaTime
            );
        }

        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}