using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMoverRightReset : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; // ���ڲ���̨���ĵ��ƶ�����
    [SerializeField] private float speed = 2f;        // ���ڲ���̨���ĵ��ٶ�
    [SerializeField] private bool right = true;
    [SerializeField] private int damage = 1;
    private bool hasDealtDamage = false;
    [SerializeField] private float damageCooldown = 3f;

    private Vector3 startPosition;

    void Start()
    {
        // ��¼����ĳ�ʼλ��
        startPosition = transform.position;
        if (right) {
            moveDistance = moveDistance * 1;
        }
        else
        {
            moveDistance = moveDistance * -1;
        }
    }

    void Update()
    {
        // �����ƶ�
        transform.position = Vector3.MoveTowards(transform.position, startPosition + new Vector3(moveDistance, 0, 0), speed * Time.deltaTime);

        // ������嵽�����ұߣ����õ������
        if (Vector3.Distance(transform.position, startPosition + new Vector3(moveDistance, 0, 0)) < 0.1f)
        {
            // ���������õ�����ߣ���ʼλ�ã�
            transform.position = startPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
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

        yield return new WaitForSeconds(damageCooldown);

        hasDealtDamage = false;
    }
}

