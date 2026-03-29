using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject Launch(Transform target)
    {
        Debug.Log("Missile launch requested.");
        return null;
    }

    public void DestroyActiveMissile()
    {
        Debug.Log("Destroy active missile requested.");
    }
}