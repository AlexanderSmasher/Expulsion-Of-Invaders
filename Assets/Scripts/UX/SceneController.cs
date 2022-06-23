using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private bool disableFadeInAnimation = false;

    private string MainMenu = "MainMenu";
    private string Game = "Game";
    private string Settings = "Settings";

    private void Start()
    {
        if (disableFadeInAnimation)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.Play("FadeIn", 0, 1);
        }
    }
    private void FadeOutFinished() => SceneManager.LoadScene(MainMenu);

    public void NewGame() => SceneManager.LoadScene(Game);
    public void GoToSettings() => SceneManager.LoadScene(Settings);
    public void GoToMenu()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }
    public void QuitGame() => Application.Quit();
}