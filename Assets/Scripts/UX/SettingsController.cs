using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown GraphicsUI;
    [SerializeField] private Toggle VolumeUI;
    [SerializeField] private TMP_Text LogingText;
    [SerializeField] private Toggle LogingUI;
    [SerializeField] private AudioMixer Master;
    [SerializeField] private GooglePlayServicesConnector GooglePSC;

    private void Start() => LoadSettings();
    public void SetVolume(bool isUnmute)
    {
        int volume;
        if (isUnmute)
        {
            Master.SetFloat("Volume", 0f);
            volume = 1;
        }
        else
        {
            Master.SetFloat("Volume", -80f);
            volume = 0;
        }
        PlayerPrefs.SetInt("VolumeSet", volume);
        PlayerPrefs.Save();
    }
    public void SetLoging(bool isLoging)
    {
        if (isLoging)
        {
            LogingText.text = "Log In";
            GooglePSC.LogIn();
        }
        else
        {
            LogingText.text = "Log Out";
            GooglePSC.LogOut();
        }
    }
    public void SetGraphics(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("GraphicsSet", level);
        PlayerPrefs.Save();
    }
    public void LoadSettings()
    {
        GraphicsUI.value = PlayerPrefs.GetInt("GraphicsSet", 2);
        VolumeUI.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("VolumeSet", 1));
        LogingUI.isOn = GooglePSC.isLogedIn();
    }
}