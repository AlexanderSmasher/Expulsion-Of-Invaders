using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private GameObject PlayerShot;
    [SerializeField] private Transform Cannon1;
    [SerializeField] private Transform Cannon2;
    [SerializeField] private List<GameObject> Flash;
    [SerializeField] private float ShootDelay;
    [SerializeField] private AudioSource ShotSFX;

    private void Fire()
    {
        Instantiate(PlayerShot, Cannon1.position, Quaternion.identity);
        Flash[0].SetActive(true);
        Instantiate(PlayerShot, Cannon2.position, Quaternion.identity);
        Flash[1].SetActive(true);
        ShotSFX.Play();
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(ShootDelay);
            Fire();
            yield return new WaitForSeconds(0.08f);
            Flash[0].SetActive(false);
            Flash[1].SetActive(false);
        }
    }
    private void Start() => StartCoroutine(Shoot());
    private void Awake()
    {
        Flash[0].SetActive(false);
        Flash[1].SetActive(false);
    }
}