using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Enemy EnemyType;
    [SerializeField] private GameObject EnemyShotPrefab;
    [SerializeField] private List<Transform> EnemyCannon;
    [SerializeField] private List<GameObject> EnemyFlash;
    [SerializeField] private GameObject EnemyExplosionPrefab;
    [SerializeField] private GameObject EnemyDamagePrefab;
    [SerializeField] private float EnemyShootDelay;
    [SerializeField] private float EnemySpeed;
    [SerializeField] private float HP;
    [SerializeField] private HPBarController HPBar;
    [SerializeField] private GameObject MarkPrefab;
    [SerializeField] private AudioSource ShotSFX;

    private float Damage;
    private float BarSize = 1f;
    private bool EnemyIsReload = true;
    
    private void Fire(Enemy type)
    {
        if (type == Enemy.MI8)
        {
            Instantiate(EnemyShotPrefab, EnemyCannon[0].position, Quaternion.identity);
            EnemyFlash[0].SetActive(true);
            ShotSFX.Play();
        }
        else if (type == Enemy.TU22)
        {
            if (EnemyIsReload)
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[0].position, Quaternion.identity);
                Instantiate(EnemyShotPrefab, EnemyCannon[1].position, Quaternion.identity);
                EnemyFlash[0].SetActive(true);
                EnemyFlash[1].SetActive(true);
                EnemyIsReload = false;
                ShotSFX.Play();
            }
            else
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[2].position, Quaternion.identity);
                Instantiate(EnemyShotPrefab, EnemyCannon[3].position, Quaternion.identity);
                EnemyFlash[2].SetActive(true);
                EnemyFlash[3].SetActive(true);
                EnemyIsReload = true;
                ShotSFX.Play();
            }
        }
        else if (type == Enemy.SU30)
        {
            if (EnemyIsReload)
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[0].position, Quaternion.identity);
                EnemyFlash[0].SetActive(true);
                EnemyIsReload = false;
                ShotSFX.Play();
            }
            else
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[1].position, Quaternion.identity);
                EnemyFlash[1].SetActive(true);
                EnemyIsReload = true;
                ShotSFX.Play();
            }
        }
        else if (type == Enemy.SU35)
        {
            if (EnemyIsReload)
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[0].position, Quaternion.identity);
                Instantiate(EnemyShotPrefab, EnemyCannon[1].position, Quaternion.identity);
                EnemyFlash[0].SetActive(true);
                EnemyFlash[1].SetActive(true);
                EnemyIsReload = false;
                ShotSFX.Play();
            }
            else
            {
                Instantiate(EnemyShotPrefab, EnemyCannon[2].position, Quaternion.identity);
                EnemyFlash[2].SetActive(true);
                EnemyIsReload = true;
                ShotSFX.Play();
            }
        }
    }
    private IEnumerator Shoot(Enemy type)
    {
        if (type == Enemy.MI8)
        {
            while (true)
            {
                yield return new WaitForSeconds(EnemyShootDelay);
                Fire(EnemyType);
                yield return new WaitForSeconds(0.08f);
                EnemyFlash[0].SetActive(false);
            }
        }
        if (type == Enemy.SU35)
        {
            while (true)
            {
                yield return new WaitForSeconds(EnemyShootDelay);
                Fire(EnemyType);
                yield return new WaitForSeconds(0.08f);
                EnemyFlash[0].SetActive(false);
                EnemyFlash[1].SetActive(false);
                EnemyFlash[2].SetActive(false);
            }
        }
        if (type == Enemy.SU30)
        {
            while (true)
            {
                yield return new WaitForSeconds(EnemyShootDelay);
                Fire(EnemyType);
                yield return new WaitForSeconds(0.08f);
                EnemyFlash[0].SetActive(false);
                EnemyFlash[1].SetActive(false);
            }
        }
        if (type == Enemy.TU22)
        {
            while (true)
            {
                yield return new WaitForSeconds(EnemyShootDelay);
                Fire(EnemyType);
                yield return new WaitForSeconds(0.08f);
                EnemyFlash[0].SetActive(false);
                EnemyFlash[1].SetActive(false);
                EnemyFlash[2].SetActive(false);
                EnemyFlash[3].SetActive(false);
            }
        }
    }
    private void Move() => transform.Translate(Vector2.down * EnemySpeed * Time.deltaTime);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayersBullet")
        {
            DamageHPBar();
            Destroy(collision.gameObject);
            GameObject damage = Instantiate(EnemyDamagePrefab, collision.transform.position, Quaternion.identity);
            Destroy(damage, 0.6f);
            if (HP <= 0)
            {
                Instantiate(MarkPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject explosion = Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.6f);
            }
        }
    }
    private void DamageHPBar()
    {
        if (HP > 0)
        {
            HP -= 1;
            BarSize -= Damage;
            HPBar.SetHP(BarSize);
        }
    }
    private void Start()
    {
        for (int i = 0; i < EnemyFlash.Count; i++)
            EnemyFlash[i].SetActive(false);
        StartCoroutine(Shoot(EnemyType));
        Damage = BarSize / HP;
    }
    private void Update() => Move();
}