using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : MonoBehaviour, IUpdatable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer spriteRenderer1;
    private void Awake()
    {
    }

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
        if (DataInfo.Instance.IsDrag)
        {
            SetAlpha(spriteRenderer,1.0f); // ���� ���� 1(������)�� ����
            SetAlpha(spriteRenderer1,1.0f); // ���� ���� 1(������)�� ����
        }
        else
        {
            SetAlpha(spriteRenderer,0f); // ���� ���� 0(����)�� ����
            SetAlpha(spriteRenderer1,0f); // ���� ���� 0(����)�� ����
        }
    }
    void SetAlpha(SpriteRenderer spriteRenderer, float alpha)   
    {
        Color color = spriteRenderer.color; // ���� ���� ��������
        color.a = alpha; // ���� �� ����
        spriteRenderer.color = color; // ������ ���� �ٽ� ����
    }

}
