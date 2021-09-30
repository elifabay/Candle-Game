using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform mum;
    Vector3 offset;

    [Range(0,50)]
    [SerializeField] float speed = 10;//Sayesinde public bir de�i�ken tan�mlamay�z ama Edit�rden y�netebiliriz.

    void Start()
    {
        offset = transform.position - mum.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Daha smooth bir �ekilde takip edebilmesi i�in vector3.lerp kullan�l�r
        //Objenin b�y�y�p k���lmesinden camera y�ksekli�inin etkilenmemesi i�in y de�eri s�f�r olarak verilir.
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(mum.transform.position.x, 0, mum.transform.position.z) + offset, Time.deltaTime*speed);
    }
}
