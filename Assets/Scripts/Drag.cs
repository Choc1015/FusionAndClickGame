
using UnityEngine;

public class Drag : MonoBehaviour
{
    [SerializeField] GameObject nextDuck;
    private bool dragging = false;
    private Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            // Move object, taking into account original offset.
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == gameObject.name && dragging)
        {
            Debug.Log("º´ÇÕ!");
            ObjectPoolManager.Instance.SpawnFromPool(nextDuck.name, collision.transform.position);
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }



}

