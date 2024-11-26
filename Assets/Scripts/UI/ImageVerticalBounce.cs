using UnityEngine;
using UnityEngine.UI;

public class ImageVerticalBounce : MonoBehaviour
{
    public RectTransform targetImage; // ������ UI �̹���
    public float speed = 2f;          // �����̴� �ӵ�
    public float range = 50f;         // �����̴� ���� (�ȼ� ����)

    private Vector2 originalPosition; // �̹����� �ʱ� ��ġ

    void Start()
    {
        // �̹����� ���� ��ġ ����
        if (targetImage != null)
        {
            originalPosition = targetImage.anchoredPosition;
        }
    }

    void Update()
    {
        if (targetImage != null)
        {
            // Sin �Լ��� ����Ͽ� ���Ʒ��� ������
            float offset = Mathf.Sin(Time.time * speed) * range;
            targetImage.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y + offset);
        }
    }
}
