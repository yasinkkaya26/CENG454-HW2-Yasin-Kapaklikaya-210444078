using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
