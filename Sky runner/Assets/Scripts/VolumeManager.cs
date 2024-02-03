using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;
    private AudioSource SFXSound;

    // Start is called before the first frame update
    void Start()
    {
        //volumeSlider = GameObject.Find("volSlider").GetComponent<Slider>();
       // Music = GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            SFXSound = GameObject.Find("SFX").GetComponent<AudioSource>();
            SFXSound.volume = PlayerPrefs.GetFloat("volume");
        }
        
        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (!PlayerPrefs.HasKey("volume"))
            {
                PlayerPrefs.SetFloat("volume", 0.5f);

            }
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }

            
    }

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (!PlayerPrefs.HasKey("volume"))
            {
                PlayerPrefs.SetFloat("volume", 0.5f);

            }
            volumeSlider.value = PlayerPrefs.GetFloat("volume");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SliderChange()
    {
        
       // Music.volume = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
        PlayerPrefs.Save();

        this.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }

}


