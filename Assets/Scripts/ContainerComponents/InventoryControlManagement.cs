using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script is attached to inventory uı object to visualize the ınventory system in game and control this
    visualization update when its inventory changes
*/
public class InventoryControlManagement : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventoryComponent;
    [SerializeField] private GameObject[] slotButtons;
    [SerializeField] private StatsComponent inventoryOwnerStats;
    void Awake()
    {
        inventoryComponent.addItemAddingListener(fillInventory);
        inventoryComponent.addRemoveItemListener(fillInventory);
    }
    void Start()
    {
        fillInventory();
    }
    /*
        This func. fills the inventory-> Creates an interactable button for each item in inventory
    */
    void fillInventory()
    {
       InventoryItem[] inventoryItems = inventoryComponent.getInventoryItems();
       for(int i=0;i<inventoryItems.Length;i++)
       {
            if(inventoryItems[i].item == null)
            {
                slotButtons[i].SetActive(false);
                continue;
            }
            if(slotButtons[i].GetComponent<ItemInInventoryComponent>().getItem() != null)
            {//if the item of this index already located then just update its count. Count is able to changed
                slotButtons[i].GetComponentInChildren<Text>().text = inventoryItems[i].count.ToString();
                continue;
            }
            //ItemInInventory comp. keeps the item. To use it functionally like using it texture ,name etc.
            slotButtons[i].GetComponent<ItemInInventoryComponent>().setItem(inventoryItems[i].item);
            //at the right corner of each button, there is a small string which shows count of the item
            slotButtons[i].GetComponentInChildren<Text>().text = inventoryItems[i].count.ToString();
            if(slotButtons[i].GetComponent<ItemInInventoryComponent>().getItem() is BoostItem)
            {
                ((BoostItem)slotButtons[i].GetComponent<ItemInInventoryComponent>().
                    getItem()).setConsumerStatsComponent(inventoryOwnerStats);
            }
            slotButtons[i].GetComponent<Button>().onClick.AddListener(//when click the item button--> consume it
                ((BoostItem)slotButtons[i].GetComponent<ItemInInventoryComponent>().
                    getItem()).consume);

            //when click to item button --> call this func. again to update inventory
            slotButtons[i].GetComponent<Button>().onClick.AddListener(fillInventory);
            slotButtons[i].SetActive(true);
       }
    }
}
