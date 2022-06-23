using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject PauseCanvas;
    [SerializeField] private GameObject UICanvas;
    [SerializeField] private DistanceCounter DCounter;

    private void Start()
    {
        UICanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        DCounter.CountRecordDistance();
        PauseCanvas.SetActive(true);
        UICanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 0f;
    }
    public void GameOver()
    {
        DCounter.CountRecordDistance();
        GameOverCanvas.SetActive(true);
        UICanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ResumeGame()
    {
        UICanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowAd()
    {
        GameOverCanvas.SetActive(false);
        UICanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        Time.timeScale = 0f;
    }
}