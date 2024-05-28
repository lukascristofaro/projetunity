using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public PlayerController player;

    public Image healtBarImage;

    private void Update()
    {
        healtBarImage.fillAmount = (float)player.health / (float)player.maxHealth;
    }

}
