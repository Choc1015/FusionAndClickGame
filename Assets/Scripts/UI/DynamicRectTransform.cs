using TMPro;
using UnityEngine;

public class DynamicRectTransform : MonoBehaviour, IUpdatable
{
    public RectTransform targetRectTransform; // 크기를 조정할 RectTransform
    public float padding = 10f; // 텍스트 양쪽 여백

    private TextMeshProUGUI textMeshPro;

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    public void OnUpdate()
    {
        UpdateRectTransformWidth();
    }

    void Awake()
    {
        // TextMeshProUGUI 컴포넌트 가져오기
        textMeshPro = GetComponent<TextMeshProUGUI>();

        if (targetRectTransform == null)
        {
            // RectTransform이 설정되지 않았다면 TextMeshPro가 있는 객체의 RectTransform을 사용
            targetRectTransform = GetComponent<RectTransform>();
        }
    }

   
    void UpdateRectTransformWidth()
    {
        if (textMeshPro == null || targetRectTransform == null)
            return;

        // 텍스트의 실제 너비를 계산하고 RectTransform에 적용
        float newWidth = textMeshPro.preferredWidth + padding * 2; // 패딩 추가
        targetRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
