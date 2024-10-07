using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 initialPosition;
    [SerializeField] private int damage = 1;
    private bool hasDealtDamage=false;
    [SerializeField] private float damageCooldown = 3f;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // �����ʼλ��
        StartCoroutine(MoveDrop()); // ��ʼ�ƶ�Һ��
    }

    private IEnumerator MoveDrop()
    {
        while (true)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // ʹҺ�δ��ڶ�̬״̬
            yield return new WaitForSeconds(1f); // ����������
            transform.Translate(Vector2.down * speed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ground") || collision.CompareTag("Sea"))
        {
            rb.bodyType = RigidbodyType2D.Static; // ֹͣ�ƶ�
            anim.SetBool("Touch", true); // ���Ŵ�������

            // �ȴ����������λ�ò����¿�ʼ
            StartCoroutine(ResetDrop());
        }

        if (collision.CompareTag("Player"))
        {
            PlayerLife player = collision.GetComponent<PlayerLife>();
            if (player != null && !hasDealtDamage)
            {
                player.TakeDamage(damage);
                hasDealtDamage = true;
                StartCoroutine(DamageCooldown());
            }
        }
    }

    private IEnumerator DamageCooldown()
    {
        Debug.Log("wait begin");
        yield return new WaitForSeconds(damageCooldown);
        Debug.Log("wait end");
        hasDealtDamage = false;
    }

    private IEnumerator ResetDrop()
    {
        yield return new WaitForSeconds(1f); // �ȴ�һ��ʱ��
        transform.position = initialPosition; // ����λ��
        anim.SetBool("Touch", false);
        rb.bodyType = RigidbodyType2D.Dynamic; // �������ö�̬
    }
}

