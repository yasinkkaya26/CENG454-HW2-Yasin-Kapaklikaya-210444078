using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;

        examManager.EnterDangerZone();

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
        }

        activeCountdown = StartCoroutine(StartMissileCountdown(collision.transform));
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player")) return;

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        examManager.CancelMissileCountdown();
        missileLauncher.DestroyActiveMissile();
        examManager.ExitDangerZone();
    }

    private IEnumerator StartMissileCountdown(Transform target)
    {
        examManager.StartMissileCountdown();

        yield return new WaitForSeconds(missileDelay);

        missileLauncher.Launch(target);
        examManager.SetMissileActive(true);

        activeCountdown = null;
    }
}