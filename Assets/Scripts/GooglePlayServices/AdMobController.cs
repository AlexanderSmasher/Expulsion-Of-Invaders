using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobController : MonoBehaviour
{
    private string InterUnitID = "*your AdMob banner id*";

    public InterstitialAd InterAd;

    private void OnEnable()
    {
        InterAd = new InterstitialAd(InterUnitID);
        AdRequest adRequest = new AdRequest.Builder().Build();
        InterAd.LoadAd(adRequest);
    }
    private void Awake() => MobileAds.Initialize(initStatus => { });

    public void ShowAd()
    {
        if (InterAd.IsLoaded())
            InterAd.Show();
    }
}