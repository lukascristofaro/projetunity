using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI AmmoText;
    public Gun gun;

    void Update()
    {
        if (gun != null)
        {
            AmmoText.text = gun.currentAmmo + "/" + gun.maxAmmo;
        }
    }
}