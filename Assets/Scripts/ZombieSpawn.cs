using System.Collections;
using UnityEngine;

public class SpawnerItem : MonoBehaviour
{
    // Variable à définir dans Unity
    public GameObject Item;
    public Transform SpawnPoint;

    private ItemChecker itemChecker;
    private bool isSpawning = false;

    public int nbRound = 0;

    public void Start()
    {
        SpawnItem();
        itemChecker = new ItemChecker("Zombie");
    }

    public void Update()
    {
        bool thereAreZombie = itemChecker.Check();
        if (thereAreZombie || isSpawning)
        {
            return;
        }
        else
        {
            Debug.Log(nbRound);
            StartCoroutine(SpawnItemsForRound());
            nbRound++;
        }
    }

    public void SpawnItem()
    {
        Instantiate(Item, SpawnPoint.position, SpawnPoint.rotation);
    }

    private IEnumerator SpawnItemsForRound()
    {
        isSpawning = true;
        for (int i = 0; i < nbRound; i++)
        {
            yield return new WaitForSeconds(1);
            SpawnItem();
        }
        isSpawning = false;
    }
}