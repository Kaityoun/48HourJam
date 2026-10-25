using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementControl : MonoBehaviour
{
    public AudioSource MenuSoundManager;
    [SerializeField] public AudioClip MenuButtonClick;
    void Start()
    {
        MenuSoundManager = GetComponent<AudioSource>();
    }
    public void OnStartPress()
    {
        MenuSoundManager.clip = MenuButtonClick;
        MenuSoundManager.Play();
        SceneManager.LoadScene("Level_Draft");
        Debug.Log("WWW");
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void OnMenuPress()
    {
        SceneManager.LoadScene("MenuScene");
    }
}