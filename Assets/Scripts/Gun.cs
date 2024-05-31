using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;




public class Gun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    public AudioClip audioshot = null;
    [SerializeField]
    public AudioClip audioEmpty = null;
    [SerializeField]
    private AudioClip audioReload = null;

    private float bulletSpeed = 10000;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    private AudioSource player_AudioSource;


    void Start()
    {
        currentAmmo = maxAmmo;
        _input = transform.root.GetComponent<StarterAssetsInputs>();
        player_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (_input.reload)
        {
            Debug.Log("Reload");
            StartCoroutine(Reload());
            return;
        }
        if(_input.shoot && currentAmmo > 0 && !Pausemenu.InPause && PlayerController.inLife)
        {
            Shoot();
            _input.shoot = false;
        } else if (_input.shoot && currentAmmo == 0){
            player_AudioSource.PlayOneShot(audioEmpty);
        }

        if (_input.pause && PlayerController.inLife)
        {
            Pausemenu.PauseInput();
            _input.pause = false;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
        player_AudioSource.PlayOneShot(audioReload);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        _input.reload = false;
    }

    void Shoot()
    {
        if (currentAmmo == 0 )
        {
            currentAmmo = 0;
        } else
        {
            currentAmmo--;
        }
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        player_AudioSource.PlayOneShot(audioshot);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 1);
    }
}
