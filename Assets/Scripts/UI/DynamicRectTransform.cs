using TMPro;
using UnityEngine;

public class DynamicRectTransform : MonoBehaviour, IUpdatable
{
    public RectTransform targetRectTransform; // ũ�⸦ ������ RectTransform
    public float padding = 10f; // �ؽ�Ʈ ���� ����

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
        // TextMeshProUGUI ������Ʈ ��������
        textMeshPro = GetComponent<TextMeshProUGUI>();

        if (targetRectTransform == null)
        {
            // RectTransform�� �������� �ʾҴٸ� TextMeshPro�� �ִ� ��ü�� RectTransform�� ���
            targetRectTransform = GetComponent<RectTransform>();
        }
    }

   
    void UpdateRectTransformWidth()
    {
        if (textMeshPro == null || targetRectTransform == null)
            return;

        // �ؽ�Ʈ�� ���� �ʺ� ����ϰ� RectTransform�� ����
        float newWidth = textMeshPro.preferredWidth + padding * 2; // �е� �߰�
        targetRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newWidth);
    }
}
