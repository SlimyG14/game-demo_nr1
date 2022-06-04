using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    public GameObject[] items;
    public float spawnInterval = 2f;
    public List<GameObject> myItems = new List<GameObject>();

    Vector2 pos;


    private void Start()
    {
        pos.y = gameObject.transform.position.y;
        pos.x = gameObject.transform.position.x;

        InvokeRepeating("SpawnItemsFunction", 0, Random.Range(2f, 6f));
    }

    void SpawnItemsFunction()
    {
        if (myItems.Count > 0)
        {
            myItems.RemoveAt(myItems.Count - 1);
        }

        GameObject itemToBeSpawned = items[Random.Range(0, items.Length)];
        GameObject spawnedItem = Instantiate(itemToBeSpawned, new Vector2(pos.x, pos.y), Quaternion.identity);
        myItems.Add(spawnedItem);


       
    }
}
