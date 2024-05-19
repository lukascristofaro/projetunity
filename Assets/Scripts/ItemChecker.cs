using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    public string tagToCheck = "ItemTag";

    public ItemChecker(string ItemTag)
    {
        tagToCheck = ItemTag;
    }

    public bool Check()
    {
        GameObject[] itemsWithTag = GameObject.FindGameObjectsWithTag(tagToCheck);

        if (itemsWithTag.Length > 0)
        {
            Debug.Log("Il y a des objets avec le tag " + tagToCheck + " dans la sc�ne.");
            return true;
        }
        else
        {
            Debug.Log("Aucun objet avec le tag " + tagToCheck + " trouv� dans la sc�ne.");
            return false;
        }
    }
}