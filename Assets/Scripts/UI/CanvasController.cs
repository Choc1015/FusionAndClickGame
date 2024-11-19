using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject lastCanvas;

    public void ChangeCanvas(GameObject clickedCanvas)
    {
        if (lastCanvas == null)
        {
            Debug.LogError(" 캔버스를 찾을 수 없습니다!");
        }

        lastCanvas.SetActive(false);
        lastCanvas = clickedCanvas;
        lastCanvas.SetActive(true);
    }
    
    public void OpenPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(true);
    }
    public void ClosedPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(false);
    }
}
