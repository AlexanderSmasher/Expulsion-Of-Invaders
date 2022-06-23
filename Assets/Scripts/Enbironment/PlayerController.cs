using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private GameObject DamagePrefab;
    [SerializeField] private float HP;
    [SerializeField] private HPBarUI HPBar;
    [SerializeField] private MarkCounter Mark;
    [SerializeField] private GameController Controller;
    [SerializeField] private AdMobController AMC;

    private float XMin;
    private float XMax;
    private float YMin;
    private float YMax;
    private float Damage;
    private float BarSize = 1f;
    private int TryCount;

    private Vector2 Padding() => new Vector2(GetComponent<BoxCollider2D>().size.x / 2, GetComponent<BoxCollider2D>().size.y / 2);
    private void FindBounds()
    {
        Camera mainCamera = Camera.main;
        XMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding().x;
        XMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding().x;
        YMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + Padding().y;
        YMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - Padding().y;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemysBullet")
        {
            DamageHPBar();
            Destroy(collision.gameObject);
            GameObject damage = Instantiate(DamagePrefab, collision.transform.position, Quaternion.identity);
            Destroy(damage, 0.6f);
            if (HP <= 0)
            {
                TryCount++;
                PlayerPrefs.SetInt("SaveTry", TryCount);
                Destroy(gameObject);
                GameObject explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
                Destroy(explosion, 0.6f);
                if (TryCount % 3 == 0 && AMC.InterAd.IsLoaded())
                {
                    Controller.ShowAd();
                    AMC.ShowAd();
                }
                else
                    Controller.GameOver();
            }
        }
        if (collision.tag == "Mark")
        {
            Destroy(collision.gameObject);
            Mark.AddMark();
        }
    }
    private void Start()
    {
        AMC.InterAd.OnAdClosed += HandleOnAdClosed;
        FindBounds();
        Damage = BarSize / HP;
        TryCount = PlayerPrefs.GetInt("SaveTry");
    }
    private void Update()
    {
        if (Input.touchCount == 1)
            Move();
    }
    private void Move()
    {
        Vector2 startTouchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        if (GetComponent<BoxCollider2D>().bounds.Contains(startTouchPos))
        {
            float offsetPosX = Mathf.Clamp(startTouchPos.x, XMin,XMax);
            float offsetPosY = Mathf.Clamp(startTouchPos.y, YMin, YMax);
            transform.position = new Vector2(offsetPosX, offsetPosY);
        }
    }
    public void HandleOnAdClosed(object sender, EventArgs args) => Controller.GameOver();
}