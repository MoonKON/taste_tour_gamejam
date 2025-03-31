using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    [SerializeField] private float moveDistance = 5f; 
    [SerializeField] private float speed = 2f;
    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + new Vector3(moveDistance, 0, 0), speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition + new Vector3(moveDistance, 0, 0)) < 0.1f)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                movingRight = true;
            }
        }
    }
}
