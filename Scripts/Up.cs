
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; //可移动距离
    [SerializeField] private float speed = 2f;        //速度

    private Vector3 startPosition;
    private bool movingUp = true;

    void Start()
    {
        //记录初始位置
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + new Vector3(0, moveDistance, 0), speed * Time.deltaTime);
            // 如果物体到达了目标距离，则改变方向为向下
            if (Vector3.Distance(transform.position, startPosition + new Vector3(0, moveDistance, 0)) < 0.1f)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            // 如果物体回到初始位置，则改变方向为向上
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingUp = true;
            }
        }
    }
}

