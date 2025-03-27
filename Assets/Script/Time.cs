using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // เพิ่ม TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 30f;
    public TextMeshProUGUI timerText; // ตัวแปรสำหรับ UI

    void Update()
    {
        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(countdownTime, 0); // ป้องกันค่าติดลบ

        timerText.text = countdownTime.ToString("F1"); // แสดงเวลาเหลือทศนิยม 1 ตำแหน่ง

        if (countdownTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}