using UnityEngine;
using TMPro; // penting untuk TMP

public class DistanceUI : MonoBehaviour
{
    public TMP_Text distanceText; // TMP_Text untuk UI

    void Update()
    {
        if (DistanceManager.instance != null && distanceText != null)
        {
            // Ambil waktu dari DistanceManager
            int distance = Mathf.FloorToInt(DistanceManager.instance.GetTime());
            distanceText.text = "Distance: " + distance + " m";
        }
    }
}
