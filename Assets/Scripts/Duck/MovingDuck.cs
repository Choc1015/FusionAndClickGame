using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDuck : MonoBehaviour, IUpdatable
{
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

    }
}
