using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This component is a container component which contains another container class (Inventory). Just
    like an interface between class and game. Lıke Inventory
*/
public class InventoryComponent : MonoBehaviour
{
    private Inventory inventory;
    private System.Action itemAdding; //provide to make some other func. works when an item adds to inventory
    private System.Action itemRemove;//provide to make some other func. works when an item remove to inventory
    
    public void addItemAddingListener(System.Action action)
    {
        itemAdding+=action;
    }
    public void addRemoveItemListener(System.Action action)
    {
        itemRemove+=action;
    }
    private void Awake()
    {
        inventory = new Inventory();
    }
    public void addItem(ConsumableItem item)
    {
        inventory.addItem(item);
        itemAdding?.Invoke();
    }
    public InventoryItem[] getInventoryItems()
    {  
        return inventory.getAllItems();
    }
    public void removeItem(string itemName)
    {
        inventory.removeItem(itemName);
        itemRemove?.Invoke();
    }

}
