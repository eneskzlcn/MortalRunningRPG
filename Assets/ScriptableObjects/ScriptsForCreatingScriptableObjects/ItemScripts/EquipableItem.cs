using UnityEngine;

/*
An Equipable Item is the interactable object that character can interact and wear it as en equipment 
like a weapon,armor,helmet etc.
*/
public class EquipableItem :IItem, IEquipment
{
    public void equip(EquipmentSlot slot)
    {
        slot.equip(this);
    }
    public override string getName()
    {
        return this.name;
    }

    public override Texture2D getTexture()
    {
        return this.texture;
    }
}
