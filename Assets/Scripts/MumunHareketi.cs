using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MumunHareketi : MonoBehaviour
{

   
    public static MumunHareketi instance;
    private Touch touch;
    private float speedModifier;
    public float speed = 3f;
    public float minCandlePos;
    public float maxCandlePos;
    public bool OnGround = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        speedModifier = 0.01f;
        minCandlePos = -6f;
        maxCandlePos = 6f;
        
    }
    private void Update()
    {
       

        if (Input.touchCount > 0) // Dokunma varsa;
        {
            touch = Input.GetTouch(0); // Degiskeni atama atama

            if (touch.phase == TouchPhase.Moved) // Dokunma basladiginda;
            {
                
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
            }
        }
        // Mumun yoldan disari cikmamasý icin gereken kod
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCandlePos, maxCandlePos), Mathf.Clamp(transform.position.y, -10f, 200f), transform.position.z);

       
        if(transform.position.y <= -3)
        {
           
            GameManager.instance.OnLevelFailed();
         }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) //Mum yolun ustunde mi?
        {
            CandleScale.instance.OnGround = true;
            MumunHareketi.instance.OnGround = true;
        }

        if (collision.transform.tag.Equals("Way"))
        {
            CandleScale.instance.meltSpeed *= 1.5f;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) 
        {
            CandleScale.instance.OnGround = true;
            MumunHareketi.instance.OnGround = true;
        }

        
    }

   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Ground")) 
        {
            CandleScale.instance.OnGround = false;
            MumunHareketi.instance.OnGround = false;
        }

        if (collision.transform.tag.Equals("Way"))
        {
            CandleScale.instance.meltSpeed = 0.15f;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Food")) //Mum yem'e carpti mi?
        {

            Destroy(other.gameObject); // Yem'i yok et
            CandleScale.instance.GetPartOfMum(); 
        }

        if (other.transform.tag.Equals("Finish"))
        {
            GameManager.instance.OnLevelCompleted();
        }

        if (other.transform.tag.Equals("Cutter"))
        {
          
            CandleScale.instance.SpawnPiece();
            this.transform.localScale -= Vector3.up * 0.1f;
        }
    }

 



}