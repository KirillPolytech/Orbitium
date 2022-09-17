using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    private static GameObject[] Collectables;
    // private static int CollectedCollactables; Количество всех собранных сфер
    private void Awake()
    {
        Collectables = GameObject.FindGameObjectsWithTag("Collectables");
    }
    public static int GetCountOfCollectables()
    {
        return Collectables.Length;
    }
    /*
    public void IncreaseCollectables()
    {
        CollectedCollactables++;
    }
    */
}
