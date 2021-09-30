using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public static bool isGameStarted = false;
    public static bool isGameEnded = false;
  //  public GameObject finishScreen;
   // public GameObject startScreen;
   // public GameObject gameOverScreen;
    int LevelCount = 0;
    public Text LevelText;
    public GameObject[] Levels;




    #region UI Degiskenleri

    public GameObject finishScreen;
    public GameObject startScreen;
    public GameObject gameOverScreen;

    #endregion
    



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }



    void Start()
    {
        
        GetLevel();
        LevelText.text = "Level " + (LevelCount + 1).ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelStarted()
    {
        //Bunlar static deðerler sahne yeniden yüklense de static olduklarý için deðiþmezler
        //çünkü instance == null ise instance this demiþiz.
        //instance null olmadýðý için bunlar da eski halinde devam ederler
        //Bu yüzden oyun baþladýðýnda olmasý gereken deðerlere sokmak lazým bu static deðiþkenleri.
        isGameStarted = true;
        isGameEnded = false;
        startScreen.SetActive(false);

    }
    public void OnLevelEnded()
    {

    }
    public void OnLevelCompleted() // Bitis ekranini cagirma
    {
        finishScreen.SetActive(true);
        isGameEnded = true;
    }

    public void OnLevelFailed() // Game Over ekranini cagirma
    {
        gameOverScreen.SetActive(true);
        isGameEnded = true;
    }
    public void NextLevel()
    {
        LevelCount++;
        PlayerPrefs.SetInt("LevelID", LevelCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GetLevel()
    {
        LevelCount = PlayerPrefs.GetInt("LevelID", 0);
        if (LevelCount > Levels.Length - 1 || LevelCount < 0)
        {
            LevelCount = 0;
            PlayerPrefs.SetInt("LevelID", LevelCount);
        }
        Instantiate(Levels[LevelCount], Vector3.zero, Quaternion.identity);
    }
}




