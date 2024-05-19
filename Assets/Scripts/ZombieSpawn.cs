using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    //variable a set sur unity
    public GameObject Item;
    public Transform SpawnPoint;

    private ItemChecker itemChecker;

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
            SpawnItem();
        }
    }

    public void SpawnItem()
    {
        //on cr�e un gameobjet dans la scn�ne �  la position, et rotation voulu.
        Instantiate(Item, SpawnPoint.position, SpawnPoint.rotation);
    }
}
