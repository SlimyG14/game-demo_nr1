using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
   //public static SetGold setGold;

    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform itemContent;
    public GameObject inventoryItem;
 
    int counterRedOre = 0;
    int counterStone = 0;
    int counterStick = 0;

    public ItemSell[] itemArray;

    private void Awake()
    {
        Instance = this;
        //setGold = new SetGold();
    }

    public void Add(Item item)
    {
        
        if (Items.Contains(item))
        {
            
            if (item.itemName.Contains("Red Ore"))
            {
                counterRedOre++;
            }
            else if (item.itemName.Contains("Stone"))
            {
                
                counterStone++;
                
            }
            else if (item.itemName.Contains("Stick"))
            {
                
                counterStick++;
            }
            ListItems();
        }
        else
        {
            Items.Add(item);
            Add(item);
        }
        
    }

    public void Remove(Item item)
    {

        if (Items.Contains(item))
        {
            if (item.itemName.Contains("Red Ore"))
            {
                counterRedOre = 0;
            }
            else if (item.itemName.Contains("Stone"))
            {
                counterStone = 0;

            }
            else if (item.itemName.Contains("Stick"))
            {

                counterStick = 0;
            }
        }

        
        Items.Remove(item);
    }
    private void Update()
    {
        //Debug.Log(Items.Count);
    }


    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
            
        }

        foreach (var item in Items)
        {
            
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("Item_Name").GetComponent<Text>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;


                if (itemName.text.ToString().Contains("Red Ore"))
                {
                    item.value = 10;
                    var itemStack = obj.transform.Find("counter").GetComponent<Text>();
                    itemStack.text = counterRedOre.ToString();
                    item.itemCounter = counterRedOre;
                }
                if (itemName.text.ToString().Contains("Stone"))
                {
                    item.value = 5;
                    var itemStack = obj.transform.Find("counter").GetComponent<Text>();
                    itemStack.text = counterStone.ToString();
                    item.itemCounter = counterStone;
                }
                if (itemName.text.ToString().Contains("Stick"))
                {
                    item.value = 3;
                    var itemStack = obj.transform.Find("counter").GetComponent<Text>();
                    itemStack.text = counterStick.ToString();
                    item.itemCounter = counterStick;
                }

        }
        
    }
    public void AddItems()
    {
        itemArray = itemContent.GetComponentsInChildren<ItemSell>();
        Debug.Log(itemArray);
        for (int i = 0; i < Items.Count; i++)
        {
            itemArray[i].AddItem(Items[i]);
        }
    }


    public void sellItem(int ammount, Item item)
    {
            
            int calc = item.value * ammount;
            int money = calc;
            Debug.Log("Money made from this one: " + money);
        SetGold.setgold.SetGoldCoins(money);
        
    }
}
