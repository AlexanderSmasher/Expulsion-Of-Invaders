using TMPro;
using UnityEngine;

public class MarkCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MarkCounterText;
    [SerializeField] private GooglePlayServicesConnector GPSConnector;
    [SerializeField] private AudioSource PickSFX;
    private int Count = 0;

    private void Start() => Count = PlayerPrefs.GetInt("SaveMarks");
    public void AddMark()
    {
        Count++;
        PlayerPrefs.SetInt("SaveMarks", Count);
        PickSFX.Play();
        GPSConnector.SaveResult(Count, 1);
    }
    private void Update() => MarkCounterText.text = Count.ToString();
}