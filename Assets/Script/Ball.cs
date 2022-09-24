using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Awake() 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Lose")
        {
            GameObject.Find("LoseEffect").GetComponent<AudioSource>().Play();

            GameObject.Find("Touch").GetComponent<Touch>().MakeBall_Lose();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.transform.tag == "Box")
        {
            GameObject.Find("GetEffect").GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);

            GameObject.Find("Touch").GetComponent<Touch>().MakeBall_Box(GetComponent<Rigidbody2D>().velocity.x ,GetComponent<Rigidbody2D>().velocity.y , this.transform.position);
        }

        if(other.transform.tag == "Speed")
        {
            GameObject.Find("GetEffect").GetComponent<AudioSource>().Play();

            Destroy(other.gameObject);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x*2,GetComponent<Rigidbody2D>().velocity.y*2);
        }
    }
}
