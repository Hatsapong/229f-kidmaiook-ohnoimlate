using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene; // กำหนดชื่อซีนที่ต้องการเปลี่ยนไป

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ตรวจสอบว่า Object ที่ชนเป็น Player หรือไม่
        {
            SceneManager.LoadScene(nextScene); // โหลดซีนใหม่
        }
    }
}