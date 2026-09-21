using UnityEngine;
using System.Collections;

public class PortalTrigger : MonoBehaviour
{
    public GameObject instructionPanel;
    public float enableDelayRealtime = 0.25f; // delay sebelum trigger aktif (realtime)
    private bool triggered = false;
    private bool canTrigger = false;

    void Awake()
    {
        if (instructionPanel == null)
        {
            GameObject found = GameObject.Find("InstructionPanel");
            if (found != null) instructionPanel = found;
        }
    }

    void Start()
    {
        // gunakan realtime delay supaya tidak terganggu Time.timeScale
        StartCoroutine(EnableTriggerRealtime(enableDelayRealtime));
    }

    IEnumerator EnableTriggerRealtime(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        canTrigger = true;
        Debug.Log($"Portal ready at {transform.position}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!canTrigger) 
        {
            Debug.Log($"Portal ignored: not ready yet, triggered by {other.name}");
            return;
        }
        if (triggered) return;
        if (!other.CompareTag("Player")) 
        {
            Debug.Log($"Portal ignored: collider by {other.name}");
            return;
        }

        // jika sudah di minigame, jangan pause lagi
        if (GameFlow.isInMiniGame) 
        {
            Debug.Log("Portal ignored: already in minigame");
            return;
        }

        triggered = true;

        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("PortalTrigger: instructionPanel is null");
        }

        GameFlow.isInMiniGame = true;
        Time.timeScale = 0f;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        Debug.Log($"Portal triggered by {other.name} at pos {other.transform.position}");
    }
}
