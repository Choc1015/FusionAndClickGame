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
            SetAlpha(spriteRenderer,1.0f); // 알파 값을 1(불투명)로 설정
            SetAlpha(spriteRenderer1,1.0f); // 알파 값을 1(불투명)로 설정
        }
        else
        {
            SetAlpha(spriteRenderer,0f); // 알파 값을 0(투명)로 설정
            SetAlpha(spriteRenderer1,0f); // 알파 값을 0(투명)로 설정
        }
    }
    void SetAlpha(SpriteRenderer spriteRenderer, float alpha)   
    {
        Color color = spriteRenderer.color; // 현재 색상 가져오기
        color.a = alpha; // 알파 값 수정
        spriteRenderer.color = color; // 수정된 색상 다시 적용
    }

}
