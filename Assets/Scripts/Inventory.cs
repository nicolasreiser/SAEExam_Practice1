using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory 
{

    List<Item> itemList;

    float inventorySize;

    UnityEvent InventoryChanged;


    public Inventory(float InventorySize)
    {
        InventoryChanged = new UnityEvent();
        itemList = new List<Item>();
        inventorySize = InventorySize;
    }

    public bool TryToAddItem(Item item)
    {
        if(InventoryWeightWithNewItem(item) <= inventorySize)
        {
            AddItemToInventory(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddItemToInventory(Item item)
    {
        itemList.Add(item);
        InventoryChanged.Invoke();
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
    public int GetInventorySize()
    {
        return itemList.Count;
    }

    private float InventoryWeightWithNewItem(Item newItem)
    {
        float totalWeight = 0;

        foreach(Item item in itemList)
        {
            totalWeight += item.GetWeight();
        }
        totalWeight += newItem.GetWeight();

        return totalWeight;
    }
    
}
