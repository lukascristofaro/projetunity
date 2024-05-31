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
            return true;
        }
        else
        {
            Debug.Log("Aucun" + tagToCheck);
            return false;
        }
    }
}