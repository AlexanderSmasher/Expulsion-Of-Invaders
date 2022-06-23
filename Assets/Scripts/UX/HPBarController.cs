using UnityEngine;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private Transform Bar;

    public void SetHP(float hp) => Bar.localScale = new Vector2(hp, 1f);
}
