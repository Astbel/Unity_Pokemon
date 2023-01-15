using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bat : Enemy
{
    public float speed;
    public float StartWaitTime;
    private float waitTime;
    public Transform movePos;
    public Transform Right_movePos;
    public Transform Left_movePos;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        waitTime = StartWaitTime;
        movePos.position = GetRandomPos();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        //Bat 初始位置
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if(waitTime <=0)
            {
                movePos.position = GetRandomPos();
                waitTime =StartWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    /*
    Describe:
    get two x raws left and right and rand it 
    */
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(Left_movePos.position.x, Right_movePos.position.x), Random.Range(Left_movePos.position.y, Right_movePos.position.y));
        return rndPos;
    }

}
