using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoadA;
    public int sceneToLoadB;
    public AudioClip clickSound;
    private AudioSource menuAudio;
    // Start is called before the first frame update

    void Start ()
    {
        menuAudio = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        menuAudio.PlayOneShot(clickSound, 1.0f);
        SceneManager.LoadScene(sceneToLoadA); // Scene to load
    }

    public void ToMenu()
    {
        menuAudio.PlayOneShot(clickSound, 1.0f);
        SceneManager.LoadScene(sceneToLoadB); // Scene to load
    }

    // Update is called once per frame
    public void QuitGame()
    {
        menuAudio.PlayOneShot(clickSound, 1.0f);
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
