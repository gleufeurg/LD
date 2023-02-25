using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Animation camAnimation;
    [SerializeField] private string levelToLoad = "MainLevelScene";

    public void Play()
    {
        Debug.Log("On part en guerre");
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Il est temps de se dire adieu");
        Application.Quit();
    }

    public void Settings()
    {
        Debug.Log("Avoir des contrôles confortables pour un controle optimal");
        camAnimation.Play();
    }
}
