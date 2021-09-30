using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScale : MonoBehaviour
{
    // GameManager gameManager; GameManager i�in instance ad�nda bir static de�i�ken tutturduk GameManager.instance ile GameManagerIn fonksiyonlar�na ula�abiliriz.
    
    
    private Touch touch;
    public GameObject Piece;
    public static CandleScale instance;
    public float speed = 0.1f;
    public bool OnGround = false;
    public float meltSpeed = 0.15f;
   


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void start()
    {

    }
    void Update()
    {
        if (!GameManager.isGameStarted || GameManager.isGameEnded) // Oyun baslamadiysa veya bittiyse
        {
            return;
        } 
        transform.Translate(Vector3.forward * (speed) * Time.deltaTime);// Ileri do�ru hareket

        this.transform.localScale -= Vector3.up * Time.deltaTime * meltSpeed; // Kuculmeye devam et

        if (this.transform.localScale.y <= 0.01f)
        {
            GameManager.instance.OnLevelFailed();
        }
    }
    public void GetPartOfMum()
    {
        this.transform.localScale += Vector3.up * 0.2f; // Y ekseninde yukselme islemi
    }
  
    public void FinishPad()
    {
        GameManager.instance.OnLevelCompleted();
    }
    public void SpawnPiece()
    {
        var PiecePos = new Vector3(MumunHareketi.instance.transform.position.x, 0.5f, this.transform.position.z - 3f);
        Instantiate(Piece, PiecePos, Quaternion.identity);
    }








}
