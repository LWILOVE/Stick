using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed;
    public bool isFly = false;
    public bool isReach = false;
    private Transform startPoint;
    private Transform circle;
    private Vector2 end;
    // Start is called before the first frame update
    void Start()
    {
        circle = GameObject.Find("CircleX").transform;
        end = circle.transform.position;
        end.y -= 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFly == false)
        {
            if (isReach == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, -3), speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, new Vector2(0, -3)) < 0.05f)
                {
                    isReach = true;
                }   
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,end, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, end) < 0.05f)
            {
                transform.position = end;
                //设置到达的针的父对象是球，这样子针就会和球一起动
                transform.parent = circle;
                isFly = false;
            }
        }
    }

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
