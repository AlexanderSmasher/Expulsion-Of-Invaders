using System.Collections;
using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DistanceCounterText;
    [SerializeField] private TextMeshProUGUI RecordDistanceCounterText;
    [SerializeField] private GooglePlayServicesConnector GPSConnector;
    private int Distance = 0;
    private int RecordDistance = 0;


    private void Start()
    {
        RecordDistance = PlayerPrefs.GetInt("SaveRecordDistance");
        StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        while(true)
        {
            Distance++;
            if (Distance >= RecordDistance)
            {
                RecordDistance = Distance;
                GPSConnector.SaveResult(RecordDistance, 0);
            }
            DistanceCounterText.text = Distance.ToString();
            RecordDistanceCounterText.text = RecordDistance.ToString();
            yield return new WaitForSeconds(1);
        }
    }
    public void CountRecordDistance() => PlayerPrefs.SetInt("SaveRecordDistance", RecordDistance);
}