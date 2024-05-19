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
            Debug.Log("Il y a des objets avec le tag " + tagToCheck + " dans la scène.");
            return true;
        }
        else
        {
            Debug.Log("Aucun objet avec le tag " + tagToCheck + " trouvé dans la scène.");
            return false;
        }
    }
}