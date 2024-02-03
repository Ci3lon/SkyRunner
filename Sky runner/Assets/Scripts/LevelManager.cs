using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lvl01()
    {
        SceneManager.LoadScene("lvl01");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }
    public void lvl02()
    {
        SceneManager.LoadScene("lvl02");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }
    public void lvl03()
    {
        SceneManager.LoadScene("lvl03");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }
    public void lvl04()
    {
        SceneManager.LoadScene("lvl04");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }
    public void lvl05()
    {
        SceneManager.LoadScene("lvl05");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }
    public void lvl06()
    {
        SceneManager.LoadScene("lvl06");
        GameObject.FindGameObjectWithTag("BGMusic").GetComponent<AudioSource>().Pause();
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
