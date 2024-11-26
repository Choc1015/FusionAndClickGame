using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            Debug.LogError(" ĵ������ ã�� �� �����ϴ�!");
        }

        DataInfo.SaveDuck();

        if (clickedCanvas.name == "��ȭ")
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
    }

    
    public void OpenPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(true);
    }
    public void ClosedPopup(GameObject clickedCanvas)
    {
        clickedCanvas.SetActive(false);
    }

    public void OnUpdate()
    {
        if (lastCanvas.name == "��ȭ")
        {
            DataInfo.Instance.IsGame = true;
        }
         
    }
}
