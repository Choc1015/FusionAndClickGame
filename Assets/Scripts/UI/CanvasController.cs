using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject lastCanvas;

    public void ChangeCanvas(GameObject clickedCanvas)
    {
        if (lastCanvas == null)
        {
            Debug.LogError(" ĵ������ ã�� �� �����ϴ�!");
        }

        lastCanvas.SetActive(false);
        lastCanvas = clickedCanvas;
        lastCanvas.SetActive(true);
    }
    
}
