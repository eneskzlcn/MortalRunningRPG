using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This component allows character to pickup items in game world by a button
public class PickupComponent : MonoBehaviour
{
    [SerializeField] private CircleCollider2D pickupCollider;
    [SerializeField] private Button pickUpButton;
    [SerializeField] private InventoryComponent inventoryComponent;
    [SerializeField] private EquipmentsComponent equipmentsComponent;
    private bool isPickupButtonPressed = false;

    void Awake()
    {
        pickupCollider = GetComponent<CircleCollider2D>();
        pickUpButton.onClick.AddListener(setPickupButtonPress);
    }
    public void setPickupButtonPress()
    {
        isPickupButtonPressed = true;
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(isPickupButtonPressed)
        {
            ItemInRealWorld itemInRealWorld = collider.GetComponent<ItemInRealWorld>();
            if(itemInRealWorld == null)return;
            if(itemInRealWorld.getItem() is Weapon)
            {
                equipmentsComponent.getEquipmentSlotBySlotType(SlotType.WEAPON).equip(
                    (IEquipment)itemInRealWorld.getItem()
                );
            }
            if(itemInRealWorld.getItem() is ConsumableItem)
            {
                inventoryComponent.addItem((ConsumableItem)itemInRealWorld.getItem());
            }
            Destroy(collider.gameObject);
            isPickupButtonPressed = false;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.GetComponent<ItemInRealWorld>() == null)return;
        pickUpButton.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<ItemInRealWorld>() == null)return;
        pickUpButton.gameObject.SetActive(true);
    }
}
