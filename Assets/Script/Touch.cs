using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch : MonoBehaviour
{
    public Rigidbody2D RightFilip;
    public Rigidbody2D LeftFilip;

    public GameObject BallPrefab;
    public Color32 BallColor;


    
    public void Right_Filip_Up()
    {
        GameObject.Find("FilipEffect").GetComponent<AudioSource>().Play();
        RightFilip.AddTorque(-5000);
    }
    public void Right_Filip_Down()
    {
        RightFilip.AddTorque(5000);
    }


    //============================


    public void Left_Filip_Up()
    {
        GameObject.Find("FilipEffect").GetComponent<AudioSource>().Play();
        LeftFilip.AddTorque(5000);
    }
    public void Left_Filip_Down()
    {
        LeftFilip.AddTorque(-5000);
    }



    
    public void MakeBall_Lose()
    {
        GameObject G = Instantiate(BallPrefab , new Vector3(0.71f , -0.88f , 0) , Quaternion.identity);
        G.GetComponent<SpriteRenderer>().color = BallColor;
    }
    public void MakeBall_Box(float A , float B , Vector3 Pos)
    {
        GameObject G = Instantiate(BallPrefab , Pos , Quaternion.identity);
        G.GetComponent<SpriteRenderer>().color = BallColor;
        G.GetComponent<Rigidbody2D>().velocity = new Vector2(A-2,B);
    }




}
