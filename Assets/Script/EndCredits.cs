using TMPro;
using UnityEngine;
using UnityEngine.UI;  // ถ้าใช้ UI Text
// หรือ
// using TMPro;  // ถ้าใช้ TextMeshPro

public class EndCredits : MonoBehaviour
{
    // ตัวแปรที่ใช้เชื่อมโยงกับ Text UI
    [SerializeField] private TextMeshProUGUI creditsText;  // ถ้าใช้ Text UI
    // หรือ
    // [SerializeField] private TextMeshProUGUI creditsText;  // ถ้าใช้ TextMeshPro

    private RectTransform textRectTransform;

    // ความเร็วในการเลื่อนข้อความ
    public float scrollSpeed = 50f;

    void Start()
    {
        // กำหนด RectTransform ของ Text UI
        textRectTransform = creditsText.GetComponent<RectTransform>();
        
        // ตั้งตำแหน่งเริ่มต้นของข้อความให้อยู่ด้านล่างสุด
        textRectTransform.anchoredPosition = new Vector2(0, -Screen.height);
    }

    void Update()
    {
        // เลื่อนข้อความขึ้น
        textRectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // ถ้าข้อความเลื่อนเกินขอบจอ ให้รีเซ็ตตำแหน่งใหม่
        if (textRectTransform.anchoredPosition.y > Screen.height)
        {
            textRectTransform.anchoredPosition = new Vector2(0, -Screen.height);
        }
    }
}