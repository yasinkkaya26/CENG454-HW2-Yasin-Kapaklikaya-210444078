using UnityEngine;

public class LandingAreaTrigger : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("Landing area entered");
        Debug.Log("HasTakenOff: " + examManager.HasTakenOff);
        Debug.Log("ThreatCleared: " + examManager.IsThreatCleared);

        if (!examManager.HasTakenOff) return;
        if (!examManager.IsThreatCleared) return;

        examManager.SetMissionComplete();
    }
}
