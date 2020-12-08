using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This is a container class which keeps items of a character.

/*
    This struct created to keep count of every item in inventory as pair with the item. Before this struct
    created, item scriptable objects had have count property to keep own count. But the time this way is using,
    changing count of an item in an inventory were changing count of  all the items kind of this item in game 
    permanently.Items and especially their counts in inventory should be independent from other items in world
    or other characters' inventory
*/
public struct InventoryItem 
{
    public ConsumableItem item;
    public float count;
}            

public class Inventory      
{

    private InventoryItem[] items = new InventoryItem[5];
    public InventoryItem[] getAllItems()
    {
        return items;
    }
    public void addItem(ConsumableItem item)
    {
        //if there is already the same item in inventory then just increase amount of the current item*/
        if(isItemInInventory(item))
        {
            increaseCountOfGivenItem(item.getName());
            return;
        }
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i].item == null)
            {   
                items[i].item = item;
                if(items[i].item is BoostItem)
                {
                   ((BoostItem)items[i].item).addOnConsumeListener(decreaseCountOfGivenItem);
                }
                items[i].count +=1;
                break;
            }
        }
    }
    public void removeItem(string itemName)
    {
        int deletedIndex = 0;
        for(int i = 0;i < items.Length;i++)
        {
            if(items[i].item == null) continue;
            if(items[i].item.getName() == itemName)
            {
                items[i].item = null;
                items[i].count = 0;
                deletedIndex = i;
            }
        }
        for (int i = deletedIndex; i < items.Length-1; i++)
        {
            items[i].item = items[i+1].item;
            items[i].count = items[i+1].count;
        }
    }
    public bool isItemInInventory(ConsumableItem item)
    {
        for (int i = 0; i < items.Length; i++)
        {   
            if(items[i].item == null) continue;
            if(items[i].item.getName() == item.getName())
            {
                return true;
            }
        }
        return false;
    }
    //writed before but does not needed yet...
    //public InventoryItem getItemFromInventory(string itemName)
    //{
    //    InventoryItem inventoryItem = new InventoryItem();
    //    for (int i = 0; i < items.Length; i++)
    //    {
    //        if(items[i].item == null) continue;
    //        if(items[i].item.getName() == itemName)
    //        {
    //            inventoryItem = items[i];
    //            break;
    //        }
    //    }
    //    return inventoryItem;
    //}
    public void increaseCountOfGivenItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i].item == null) continue;
            if(items[i].item.getName() == itemName)
            {
                items[i].count++;
                break;
            }
        }
    }

    public void decreaseCountOfGivenItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i].item == null) continue;
            if(items[i].item.getName() == itemName)
            {
                items[i].count--;
                if(items[i].count <= 0)//if count of the item is 0 then need to remove it
                {
                    removeItem(items[i].item.getName());
                }
                break;
            }
        }
    }
}
