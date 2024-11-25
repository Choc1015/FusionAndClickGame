
using System;
using UnityEngine;

[System.Serializable]
public class DuckData
{
    public int NextDuck;
    public string SpriteName; // Sprite�� �̸��� ����
    public Vector3 Position; // ��ġ ����
}

public class Duck : MonoBehaviour, IUpdatable
{
    public int nextDuck = 0;
    private SpriteRenderer spriteRenderer;
    private bool Dragging = false;
    private Vector3 offset;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        if (!DataInfo.Instance.IsGame)
        {   
            gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
            gameObject.GetComponent<Duck>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
        }
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private void OnMouseDown()
    {
        if (!DataInfo.Instance.IsGame)
        {
            Debug.Log("�� ������ ����");
            return;
        }
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Dragging = true;
    }

    private void OnMouseUp()
    {
        // Stop Duckging.
        Dragging = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        FusionDuck(collision);

        if (Dragging && collision.gameObject.CompareTag("Wall"))
        {
            Dragging = false;
        }

    }

    private void FusionDuck(Collision2D collision)
    {
        if (Dragging && collision.gameObject.CompareTag("Duck"))
        {
            if (collision.gameObject.GetComponent<Duck>().nextDuck == nextDuck)
            {
                Debug.Log("����!");

                // ���ļ� Ŭ����� �ʴ� �� ����
                int ClickCoint = (int)Mathf.Pow(1.5f, nextDuck + 1) * 2;
                DataInfo.Instance.ClickDuckCoin -= ClickCoint;
                DataInfo.Instance.PerSecondCoin -= ClickCoint * 2;

                nextDuck++;
                Dragging = false;

                // ������ ������ ���� �� ����
                ClickCoint = (int)Mathf.Pow(1.5f, nextDuck + 1);
                DataInfo.Instance.ClickDuckCoin += ClickCoint;
                DataInfo.Instance.PerSecondCoin += ClickCoint * 2;

                // ��ġ�� ���
                spriteRenderer.sprite = SpawnManager.Instance.DuckImage[nextDuck];
                gameObject.transform.position = (gameObject.transform.position + collision.transform.position) / 2f;
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
                collision.gameObject.GetComponent<Duck>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
                ObjectPoolManager.Instance.DeSpawnToPool(collision.gameObject.name, collision.gameObject);
                CheckNewDuck();
                DataInfo.Instance.CurrentDuckCount--;
            }
        }
    }

    private void CheckNewDuck()
    {
        if (nextDuck - 1 == DataInfo.Instance.NewDucklevel)
        {
            Debug.Log($"���ο� ���� {nextDuck - 1}, {DataInfo.Instance.NewDucklevel}");

            DataInfo.Instance.NewDucklevel++;
            SpawnManager.Instance.ChangeCanvas();
        }
        
        Debug.Log($"{nextDuck}, {DataInfo.Instance.NewDucklevel}");

    }

    public void OnUpdate()
    {
        if (Dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}

