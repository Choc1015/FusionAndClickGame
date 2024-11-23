using System.Collections;
using UnityEngine;

public class RandomForce2D : MonoBehaviour
{
    public float minForce = 5f; // �ּ� ��
    public float maxForce = 15f; // �ִ� ��
    public float minInterval = 5f; // �ּ� ���� (��)
    public float maxInterval = 10f; // �ִ� ���� (��)


    private Rigidbody2D rb;
    private float scaleValue = 1.8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ApplyRandomForce());
    }

    private IEnumerator ApplyRandomForce()
    {
        while (true)
        {


            // ���� �ð� ���� ���
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // ���� ���� ���� ���
            float force = Random.Range(minForce, maxForce);
            Vector2 direction = Random.insideUnitCircle.normalized;
            Debug.Log(direction);
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-scaleValue, scaleValue, scaleValue);
            }
            else if (direction.x <= 0) 
            {
                transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
            }
            rb.AddForce(direction * force, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = Vector2.zero;


        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Duck"))
        rb.velocity = Vector2.zero;
    }
}
