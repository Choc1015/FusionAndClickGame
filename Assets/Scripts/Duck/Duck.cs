
using System;
using UnityEngine;

[System.Serializable]
public class DuckData
{
    public int NextDuck;
    public string SpriteName; // Sprite의 이름을 저장
    public Vector3 Position; // 위치 저장
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
            Debug.Log("못 움직임 ㅅㄱ");
            return;
        }


        // Record the difference between the objects centre, and the clicked point on the camera plane.
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Dragging = true;
        DataInfo.Instance.IsDrag = Dragging;
    }

    private void OnMouseOver()
    {

    }

    private void OnMouseUp()
    {
        // Stop Duckging.
        Dragging = false;
        DataInfo.Instance.IsDrag = Dragging;

        if (DataInfo.Instance.IsTrash)
        {
            DeleteDuck();
        }

        if (!IsInRange(gameObject.transform.position.x, -5, 5) || !IsInRange(gameObject.transform.position.y, -4, 8))
        {
            gameObject.transform.position = ObjectPoolManager.Instance.RandomSpawn();
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        FusionDuck(collision);

        if (Dragging && collision.gameObject.CompareTag("Wall")&& !DataInfo.Instance.IsTrash)
        {
            Dragging = false;
        }

    }

    private void DeleteDuck()
    {
        int ClickCoint = (int)Mathf.Pow(1.5f, nextDuck + 1);
        DataInfo.Instance.ClickDuckCoin -= ClickCoint;
        DataInfo.Instance.PerSecondCoin -= ClickCoint * 2;
        gameObject.GetComponent<SpriteRenderer>().sprite = SpawnManager.Instance.DuckImage[DataInfo.Instance.SpawnDuckLevel];
        gameObject.GetComponent<Duck>().nextDuck = DataInfo.Instance.SpawnDuckLevel;
        ObjectPoolManager.Instance.DeSpawnToPool(gameObject.name, gameObject);
        DataInfo.Instance.CurrentDuckCount--;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("들어와있는중");

        if (Dragging && collision.gameObject.CompareTag("Wall"))
        {
            //Dragging = false;
        }
        //if(!Dragging && collision.gameObject.CompareTag("Wall") && !DataInfo.Instance.IsTrash)
        //{
            
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        Debug.Log("나가는중");

        if (Dragging && collision.gameObject.CompareTag("Wall"))
        {
            gameObject.transform.position = Vector3.zero;
        }
    }

    private void FusionDuck(Collision2D collision)
    {
        if (Dragging && collision.gameObject.CompareTag("Duck"))
        {
            

            if (collision.gameObject.GetComponent<Duck>().nextDuck == nextDuck)
            {
                Debug.Log("병합!");
                AudioManager.Instance.PlayDuckSound();
                // 합쳐서 클릭당과 초당 값 감소
                int ClickCoint = (int)Mathf.Pow(1.5f, nextDuck + 1) * 2;
                DataInfo.Instance.ClickDuckCoin -= ClickCoint;
                DataInfo.Instance.PerSecondCoin -= ClickCoint * 2;

                nextDuck++;
                Dragging = false;

                // 증가된 레벨에 따른 값 증가
                ClickCoint = (int)Mathf.Pow(1.5f, nextDuck + 1);
                DataInfo.Instance.ClickDuckCoin += ClickCoint;
                DataInfo.Instance.PerSecondCoin += ClickCoint * 2;

                // 합치는 기능
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
            Debug.Log($"새로운 오리 {nextDuck - 1}, {DataInfo.Instance.NewDucklevel}");

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
    public bool IsInRange(float x, float min, float max)
    {
        return x >= min && x <= max;
    }



}

