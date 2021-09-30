using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform mum;
    Vector3 offset;

    [Range(0,50)]
    [SerializeField] float speed = 10;//Sayesinde public bir deðiþken tanýmlamayýz ama Editörden yönetebiliriz.

    void Start()
    {
        offset = transform.position - mum.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Daha smooth bir þekilde takip edebilmesi için vector3.lerp kullanýlýr
        //Objenin büyüyüp küçülmesinden camera yüksekliðinin etkilenmemesi için y deðeri sýfýr olarak verilir.
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(mum.transform.position.x, 0, mum.transform.position.z) + offset, Time.deltaTime*speed);
    }
}
