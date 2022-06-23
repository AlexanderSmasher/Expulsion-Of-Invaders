using UnityEngine;

public class BulletState : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    private void Update() => transform.Translate(Vector2.up * Speed * Time.deltaTime);
}
