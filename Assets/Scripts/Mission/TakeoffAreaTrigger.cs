using UnityEngine;

public class TakeoffAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        examManager.MarkTakeoff();
    }
}