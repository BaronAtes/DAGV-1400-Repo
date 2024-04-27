using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToLoad;
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
        SceneManager.LoadScene(sceneToLoad); // Scene to load
    }

    // Update is called once per frame
    public void QuitGame()
    {
        menuAudio.PlayOneShot(clickSound, 1.0f);
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
