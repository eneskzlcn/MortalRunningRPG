using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SlotType//The EquipmentSlot's choose what kind of an Equipment they are keeping.
{
    WEAPON,ARMOR,ELSE
}
public class EquipmentSlot//A character uses equipment slots to keep its equipments. One slot for one equipment.
{
    private IEquipment equipment;
    [SerializeField] public SlotType slotType;
    private System.Action<IEquipment> onEquip;
    private System.Action<IEquipment> onUnequip;

    public void equip(IEquipment equipment)
    {
        unequip();
        this.equipment = equipment;
        onEquip?.Invoke(equipment);
    }
    public void unequip()
    {
        if(this.equipment == null)return;
        onUnequip?.Invoke(this.equipment);
        this.equipment = null;
    }
    public void addOnEquipListener(System.Action<IEquipment> action)
    {
        onEquip+=action;
    }
    public void addOnUnequipListener(System.Action<IEquipment> action)
    {
        onUnequip+= action;
    }
    public IEquipment getEquipment()
    {
        return this.equipment;
    }
    public SlotType getSlotType()
    {
        return slotType;
    }
    public void setSlotType(SlotType slotType)
    {
        this.slotType = slotType;
    }
}
