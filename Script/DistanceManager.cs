using UnityEngine;
using TMPro;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager instance;
    public TextMeshProUGUI distanceText;
    public bool isGameOver = false;

    private float timer = 0f;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        timer += Time.deltaTime;
        int distance = Mathf.FloorToInt(timer); // tiap detik = 1 m
        distanceText.text = "Distance: " + distance + " m";
    }

    public float GetTime()
    {
        return timer;
    }
}
