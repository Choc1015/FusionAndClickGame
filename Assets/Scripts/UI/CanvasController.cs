using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour,IUpdatable
{
    [SerializeField] GameObject lastCanvas;
   


   

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    public void ChangeCanvas(GameObject clickedCanvas)
    {
        if (lastCanvas == null)
        {
            Debug.LogError(" 캔버스를 찾을 수 없습니다!");
        }

        DataInfo.SaveDuck();

        if (clickedCanvas.name == "강화")
        {
            DataInfo.Instance.IsGame = true;
            //ObjectPoolManager.Instance.hideBox.SetActive(true);
            Debug.Log(DataInfo.Instance.IsGame);
        }
        else
        {
            //DataInfo.SaveDuck();
            DataInfo.Instance.IsGame = false;
            //ObjectPoolManager.Instance.hideBox.SetActive(false);
        }

        lastCanvas.SetActive(false);
        lastCanvas = clickedCanvas;
        lastCanvas.SetActive(true);

        DataInfo.Instance.AllDataRoading();
    }

    
    public void OpenPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(true);
        DataInfo.Instance.AllDataRoading();
    }
    public void ClosedPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(false);
        DataInfo.Instance.AllDataRoading();
    }

    public void OnUpdate()
    {
        if (lastCanvas.name == "강화")
        {
            DataInfo.Instance.IsGame = true;
        }
         
    }


}
