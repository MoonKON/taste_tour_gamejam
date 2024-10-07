
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; // ���ڲ���̨���ĵ��ƶ�����
    [SerializeField] private float speed = 2f;        // ���ڲ���̨���ĵ��ٶ�

    private Vector3 startPosition;
    private bool movingLeft = true;

    void Start()
    {
        // ��¼����ĳ�ʼλ��
        startPosition = transform.position;
    }

    void Update()
    {
        // ���ݷ����ж������������������ƶ�
        if (movingLeft)
        {
            // �����ƶ�
            transform.position = Vector3.MoveTowards(transform.position, startPosition - new Vector3(moveDistance, 0, 0), speed * Time.deltaTime);

            // ������嵽����Ŀ����룬��ı䷽��Ϊ����
            if (Vector3.Distance(transform.position, startPosition - new Vector3(moveDistance, 0, 0)) < 0.1f)
            {
                movingLeft = false;
            }
        }
        else
        {
            // �����ƶ������س�ʼλ�ã�
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

            // �������ص���ʼλ�ã���ı䷽��Ϊ����
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingLeft = true;
            }
        }
    }
}
