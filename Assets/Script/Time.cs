using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 30f;
    public TextMeshProUGUI timerText; // ตัวแปรสำหรับ UI

    void Update()
    {
        countdownTime -= Time.deltaTime;
        countdownTime = Mathf.Max(countdownTime, 0); // ป้องกันค่าติดลบ

        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // แสดงเวลาในรูปแบบ MM:SS

        if (countdownTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
