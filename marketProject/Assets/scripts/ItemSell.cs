using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSell : MonoBehaviour
{
    public Item item;

    private void Update()
    {
        //Debug.Log(item);
    }

    public void sellItem()
    {
        Debug.Log("Item that im selling before selling: " + item);
        InventoryManager.Instance.AddItems();
        InventoryManager.Instance.Remove(item);
        InventoryManager.Instance.sellItem(item.itemCounter, item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        Debug.Log("AddItem item: "+item);
    }
}
