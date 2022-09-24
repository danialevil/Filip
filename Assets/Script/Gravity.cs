using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject Ball;
    public Rigidbody2D rb;
    public float Dis;
    public Vector3 dir;
    
    public int Manager;
    public float Timer;

    public Color32 ColorFalse;
    public Color32 ColorTrue;

    void FixedUpdate()
    {
        Ball = GameObject.FindWithTag("Ball");

        dir = (Ball.transform.position - rb.transform.position).normalized;

        Dis = Vector2.Distance(this.gameObject.transform.position , Ball.transform.position);

        
        if(Manager == 0)
        {
            if(Dis <= 3)
            {
                Ball.transform.position = Vector2.MoveTowards (Ball.transform.position, this.transform.position , (10 * 1/Dis) * Time.fixedDeltaTime);
            }
            if(Dis<=0.5f)
            {
                Manager = 1;
            }
        }


        if(Manager == 1)
        {
            Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Ball.transform.position = this.transform.position;

            Manager = 2;
        }
        

        if(Manager == 2)
        {
            Timer += 1 *Time.deltaTime;

            if(Timer >= 3)
            {
                Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

                Ball.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(5,15),Random.Range(5,15));

                GetComponent<SpriteRenderer>().color = ColorFalse;

                Manager = 3;
            }
        }

        if(Manager == 3)
        {
            Timer += 1 *Time.deltaTime;
            
            if(Timer >= 18)
            {
                GetComponent<SpriteRenderer>().color = ColorTrue;
                Timer = 0;
                Manager = 0;
            }
        }


    }

}
