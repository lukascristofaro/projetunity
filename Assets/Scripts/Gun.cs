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
    private float bulletSpeed = 10000;

    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        _input = transform.root.GetComponent<StarterAssetsInputs>();
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
        if(_input.shoot && currentAmmo > 0)
        {
            Shoot();
            _input.shoot = false;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("reloading");
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
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 1);
    }
}
