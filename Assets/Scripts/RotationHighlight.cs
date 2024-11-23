using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationHighlight : MonoBehaviour, IUpdatable
{
    public float Speed = 1;

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        transform.rotation = Quaternion.identity;
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    public void OnUpdate()
    {
        transform.Rotate(Vector3.back *  Speed * Time.deltaTime);
    }
}
