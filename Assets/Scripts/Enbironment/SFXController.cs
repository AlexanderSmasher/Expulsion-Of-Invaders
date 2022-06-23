using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private AudioSource SFX;

    private void Start() => SFX.Play();
}