using System.Collections;
using UnityEngine;

public class BootHandler : MonoBehaviour
{
    [SerializeField] private Animator FadeAnimator = null;
    [SerializeField] private int SceneRunTime = 0;

    private void Start() => StartCoroutine(Timer());

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(SceneRunTime);
        FadeAnimator.SetTrigger("FadeOut");
    }
}
