using UnityEngine;
using UnityEngine.UI;

public class ImageVerticalBounce : MonoBehaviour
{
    public RectTransform targetImage; // 움직일 UI 이미지
    public float speed = 2f;          // 움직이는 속도
    public float range = 50f;         // 움직이는 범위 (픽셀 단위)

    private Vector2 originalPosition; // 이미지의 초기 위치

    void Start()
    {
        // 이미지의 시작 위치 저장
        if (targetImage != null)
        {
            originalPosition = targetImage.anchoredPosition;
        }
    }

    void Update()
    {
        if (targetImage != null)
        {
            // Sin 함수를 사용하여 위아래로 움직임
            float offset = Mathf.Sin(Time.time * speed) * range;
            targetImage.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y + offset);
        }
    }
}
