using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    Transform point1;
    [SerializeField]
    Transform point2;
    [SerializeField]
    float speed = 0.5f;
    [SerializeField]
    int directionX;
    [SerializeField]
    int directioinY;
    [SerializeField]
    bool typeIsHor = true;

    Vector3 travelDirection;
    Vector3 currentDirection;

    void Start()
    {
        travelDirection = new Vector3(directionX, directioinY);
        currentDirection = travelDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (typeIsHor)
        {
            if (transform.position.x > point2.position.x)
            {
                currentDirection = -travelDirection;
            }
            else if (transform.position.x < point1.position.x)
            {
                currentDirection = travelDirection;
            }
        }
        else
        {
            if (transform.position.y < point2.position.y)
            {
                currentDirection = travelDirection;
            }
            else if (transform.position.y > point1.position.y)
            {
                currentDirection = -travelDirection;
            }
        }

        transform.position += currentDirection * speed * Time.deltaTime;
    }
}
