using TMPro;
using UnityEngine;

public class FlightExamManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    [Header("Audio")]
    [SerializeField] private AudioSource successAudioSource;

    private bool hasTakenOff = false;
    private bool hasEnteredDangerZone = false;
    private bool missileCountdownActive = false;
    private bool missileActive = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public bool HasTakenOff => hasTakenOff;
    public bool HasEnteredDangerZone => hasEnteredDangerZone;
    public bool IsMissileCountdownActive => missileCountdownActive;
    public bool IsMissileActive => missileActive;
    public bool IsThreatCleared => threatCleared;
    public bool IsMissionComplete => missionComplete;

    private void Start()
    {
        statusText.text = "Ready";
        RefreshMissionText();
    }

    public void MarkTakeoff()
    {
        if (hasTakenOff) return;

        hasTakenOff = true;
        statusText.text = "Takeoff successful.";
        RefreshMissionText();
    }

    public void EnterDangerZone()
    {
        hasEnteredDangerZone = true;
        threatCleared = false;
        statusText.text = "Entered a Dangerous Zone!";
        RefreshMissionText();
    }

    public void StartMissileCountdown()
    {
        missileCountdownActive = true;
        RefreshMissionText();
    }

    public void CancelMissileCountdown()
    {
        missileCountdownActive = false;
        RefreshMissionText();
    }

    public void SetMissileActive(bool active)
    {
        missileActive = active;
        missileCountdownActive = false;
        RefreshMissionText();
    }

    public void ExitDangerZone()
    {
        missileCountdownActive = false;
        missileActive = false;

        if (hasEnteredDangerZone)
        {
            threatCleared = true;
            statusText.text = "Threat cleared. Return and land safely.";
        }
        else
        {
            statusText.text = "Safe zone.";
        }

        RefreshMissionText();
    }

    public void SetMissionComplete()
    {
        missionComplete = true;
        statusText.text = "Mission complete.";

        if (successAudioSource != null)
        {
            successAudioSource.Play();
        }

        RefreshMissionText();
    }

    private void RefreshMissionText()
    {
        if (missionComplete)
        {
            missionText.text = "Mission: Completed";
            return;
        }

        if (!hasTakenOff)
        {
            missionText.text = "Mission: Take off from runway";
            return;
        }

        if (!hasEnteredDangerZone)
        {
            missionText.text = "Mission: Fly to the danger corridor";
            return;
        }

        if (missileCountdownActive)
        {
            missionText.text = "Mission: Warning - missile countdown active";
            return;
        }

        if (missileActive)
        {
            missionText.text = "Mission: Escape the missile";
            return;
        }

        if (threatCleared)
        {
            missionText.text = "Mission: Return and land safely";
            return;
        }

        missionText.text = "Mission: In progress";
    }

    public void OnMissileHit()
    {
        missileActive = false;
        missileCountdownActive = false;
        threatCleared = false;

        statusText.text = "Missile hit! Return to runway and try again.";
        RefreshMissionText();
    }
}