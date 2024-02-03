using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public CharacterManager characterController;
    private int ColorID = 0;
    public Material[] PlayerColor;
    public Image ColorChangeButton;
    public GameObject SettingsUI;
    public GameObject MenuUI;
    public GameObject LevelsUI;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Color"))
        {
            PlayerPrefs.SetInt("Color", 0);
        }
        ColorChangeButton.color = PlayerColor[PlayerPrefs.GetInt("Color")].color;

        characterController = FindObjectOfType<CharacterManager>();

        if (!GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Levels()
    {
        LevelsUI.SetActive(true);
        MenuUI.SetActive(false);
        SettingsUI.SetActive(false);
    }
    public void GameStart()
    {
        SceneManager.LoadScene("lvl01");
        //BackgroundMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
    public void Options()
    {
        SettingsUI.SetActive(true);
        MenuUI.SetActive(false);
        LevelsUI.SetActive(false);
    }
    public void Back()
    {
        SettingsUI.SetActive(false);
        MenuUI.SetActive(true);
        LevelsUI.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ColorChange()
    {
        if(PlayerPrefs.HasKey("Color"))
        {
            ColorID = PlayerPrefs.GetInt("Color");
        }
        
        ColorID++;

        if (ColorID > 6) 
        { 
            ColorID = 0;
        
        }

        PlayerPrefs.SetInt("Color", ColorID);
        PlayerPrefs.Save();
        ColorChangeButton.color = PlayerColor[PlayerPrefs.GetInt("Color")].color;

    }


}
    