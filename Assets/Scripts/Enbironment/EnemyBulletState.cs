using UnityEngine;

public class EnemyBulletState : MonoBehaviour
{
    private void Update() => Move();
    private void Move() => transform.Translate(Vector2.down * 10 * Time.deltaTime);
}
