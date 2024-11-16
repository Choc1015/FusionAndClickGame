
using UnityEngine;

public class Drag : MonoBehaviour, IUpdatable
{
    [SerializeField] GameObject NextDuck;

    public int nextDuck = 0;
    private SpriteRenderer spriteRenderer;
    private bool dragging = false;
    private Vector3 offset;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateManager.Instance?.Register(this);
        gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
        gameObject.GetComponent<Drag>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
    }

    private void OnDisable()
    {
        UpdateManager.Instance?.Unregister(this);
    }

    private void OnMouseDown()
    {
        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }

    private void OnMouseUp()
    {
        // Stop dragging.
        dragging = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(dragging && collision.gameObject.CompareTag("Duck"))
        {
            if (collision.gameObject.GetComponent<Drag>().nextDuck == nextDuck)
            {
                Debug.Log("º´ÇÕ!");
                nextDuck++;
                dragging = false;
                spriteRenderer.sprite = SpawnManager.Instance.DuckImage[nextDuck];
                gameObject.transform.position = (gameObject.transform.position + collision.transform.position) / 2f;
                collision.gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
                collision.gameObject.GetComponent<Drag>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
                ObjectPoolManager.Instance.DeSpawnToPool(collision.gameObject.name, collision.gameObject);
            }
        }

        if (dragging && collision.gameObject.CompareTag("Wall"))
        {
            dragging = false;
        }
        
    }

    public void OnUpdate()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}

