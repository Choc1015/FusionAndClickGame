using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashEvent : MonoBehaviour
{
    public Sprite TrashMotion;
    private SpriteRenderer spriteRenderer;
    Sprite Temp;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Temp = spriteRenderer.sprite;
        spriteRenderer.sprite = TrashMotion;
        DataInfo.Instance.IsTrash = true;
        DataInfo.Instance.AllDataRoading();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        DataInfo.Instance.IsTrash = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DataInfo.Instance.IsTrash = false;
        spriteRenderer.sprite = Temp;
        DataInfo.Instance.AllDataRoading();
    }
}
