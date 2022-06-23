using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;
    private float SpawnTime = 5f;

    private void SpawnEnemy() => Instantiate(Enemy[Random.Range(0, Enemy.Length)], 
        new Vector2(Random.Range(-40, 40) * 0.1f, transform.position.y), Quaternion.identity);
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnTime);
            SpawnEnemy();
        }
    }
    private void Start() => StartCoroutine(EnemySpawner());
}