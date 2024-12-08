using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuckImage : MonoBehaviour
{
    [SerializeField] public int ImageNumber = 0;

    private Image spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }

    private void Start()
    {
        spriteRenderer.sprite = SpawnManager.Instance.DuckImage[ImageNumber];
    }
}
