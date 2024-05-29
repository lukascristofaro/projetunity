using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    //variable a set sur unity
    public GameObject Item;
    public Transform SpawnPoint;

    private ItemChecker itemChecker;

    public int nbRound = 1;

    public void Start()
    {
        SpawnItem();
        itemChecker = new("Zombie");


    }

    public void Update()
    {
        bool thereAreZombie = itemChecker.Check();
        if (thereAreZombie)
        {
            return;
        } else
        {
            for (int i = 0; i < (int)Math.Pow(nbRound * 2, 2); i++)
            {
                StartCoroutine(WaitForZombieSpawn(1));

            }
        }
    }

    public void SpawnItem()
    {
        Instantiate(Item, SpawnPoint.position, SpawnPoint.rotation);
    }

    private IEnumerator WaitForZombieSpawn(int time)
    {
        yield return new WaitForSeconds(time);
        SpawnItem();

    }
}
