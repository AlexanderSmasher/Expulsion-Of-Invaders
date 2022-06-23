using UnityEngine;
using GooglePlayGames;

public class GooglePlayServicesConnector : MonoBehaviour
{
    private string[] LeaderBoard = { "*first leaderbord id*", "*second leaderbord id*" };
    private bool IsLoged = false;

    private void Start()
    {
        PlayGamesPlatform.Activate();
        LogIn();
    }

    public void SaveResult(int score, int scoreType) => Social.ReportScore(score, LeaderBoard[scoreType], success => { });
    public void ShowLeaderBord() => ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI();

    public void LogIn()
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Social.localUser.Authenticate(success =>
            {
                if (success)
                    IsLoged = true;
                else
                    IsLoged = false;
            });
        }
    }
    public void LogOut()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            PlayGamesPlatform.Instance.SignOut();
            IsLoged = false;
        }
    }
    public bool isLogedIn()
    {
        if (IsLoged)
            return true;
        else
            return false;
    }
}