
using System;
using UnityEngine;

public class Duck : MonoBehaviour, IUpdatable
{
    [SerializeField] GameObject NextDuck;

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
        gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
        gameObject.GetComponent<Duck>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private void OnMouseDown()
    {
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
                Debug.Log("º´ÇÕ!");
                nextDuck++;
                Dragging = false;
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

