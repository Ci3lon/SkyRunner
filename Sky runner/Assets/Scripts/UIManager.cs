using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject WinUI;
    public GameObject PauseUI;
    public Slider ProgressSlider;
    private GameObject EndCube;
    public Button NextLevelButton;
    bool escape;
    private Transform Player;
    private Transform MovingCube;
    private bool CanRestart = false;
    private CharacterManager character;
    private GameObject BGroundMusic;
    bool sound = true;
    bool gopause = false;
    bool nextlevel = false;


    void Start()
    {       
        Time.timeScale = 1;
        escape = false;
        GameOverUI.SetActive(false);
        WinUI.SetActive(false);
        PauseUI.SetActive(false);

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        character = Player.GetComponent<CharacterManager>();
        EndCube = GameObject.FindGameObjectWithTag("EndGame");
        MovingCube = GameObject.FindGameObjectWithTag("MovingCube").transform;

        BGroundMusic = GameObject.FindGameObjectWithTag("BGMusic");

        ProgressSlider.minValue = Player.position.x;
        ProgressSlider.maxValue = EndCube.transform.position.x - 2;

    }
    private void Update()
    {
        ProgressSlider.value = Player.position.x; 

        if (Input.GetKeyDown(KeyCode.Escape) && !gopause)
        {
            if (!escape)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0;
                escape = true;

            }
            else
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1;
                escape = false;

            }
        }

        if (MovingCube.position.x - Player.position.x >= 8 )
        {

            if (sound) 
            { 
            GameOverFunction();
            sound = false;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && CanRestart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Space) && nextlevel)
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            NextLevelButton.GetComponent<Button>().onClick.Invoke();
        }

    }

    public void lvl02()
    {
        SceneManager.LoadScene("lvl02");
    }
    public void lvl03()
    {
        SceneManager.LoadScene("lvl03");
    }
    public void lvl04()
    {
        SceneManager.LoadScene("lvl04");
    }
    public void lvl05()
    {
        SceneManager.LoadScene("lvl05");
    }
    public void lvl06()
    {
        SceneManager.LoadScene("lvl06");
    }

    public void GameOverFunction()
    {
        character.source.Pause();
        character.source.clip = character.sounds[1];
        character.source.Play();
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
        gopause = true;
        CanRestart = true;
  
    }
    public void WinFunction()
    {
        character.source.clip = character.sounds[2];
        character.source.Play();
        Time.timeScale = 0;
        WinUI.SetActive(true);
        gopause = true;
        nextlevel = true;
      
    }


    //public void Restart()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
        escape = false;
    }
   
}
