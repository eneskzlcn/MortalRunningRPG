using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This script controls equipments of the character. A Container Component...
*/

[System.Serializable]
public struct EquipmentRendererMap//maps the character equipments with the renderers which will render them if they are.
{
    public SlotType slotType; //this for [serialize the type of equipment from editor easily]
    public EquipmentSlot equipmentSlot;
    public SpriteRenderer renderer; // texture of equipments will rendered by a sprite renderer
}

public class EquipmentsComponent : MonoBehaviour
{
    [SerializeField] private EquipmentRendererMap[] equipmentRendererPair;    
    private void Awake()
    {
        addEquipmentSlots();
        configureEquipments();
    }
    /*works in awake to add listeners to each equipment slot. Each equipment will automatically render by
        the sprite render they already mapped in when their onequip func. works.(when it equip by somebody)
    */
    private void configureEquipments()
    {      
        for (int i = 0; i < equipmentRendererPair.Length; i++)
        {
            equipmentRendererPair[i].equipmentSlot.addOnEquipListener((IEquipment equipment)=>
            {
                SpriteRenderer chosenRenderer = null;
                if(equipment is Weapon)
                {
                    chosenRenderer = getRendererBySlotType(SlotType.WEAPON);
                }
                Texture2D equipmentTexture =((IItem)equipment).getTexture();
                Sprite equipmentSprite = Sprite.Create(equipmentTexture, 
                    new Rect(0.0f, 0.0f, equipmentTexture.width, equipmentTexture.height), 
                        new Vector2(0.5f, 0.5f), 100.0f);
                chosenRenderer.sprite = equipmentSprite;
            });
        }
    }
    //return the equipment slot by the given slotType
    public EquipmentSlot getEquipmentSlotBySlotType(SlotType slotType)
    {
        for (int i = 0; i < equipmentRendererPair.Length; i++)
        {
            if(equipmentRendererPair[i].slotType == slotType)
            {
                return equipmentRendererPair[i].equipmentSlot;
            }
        }
        return null;
    }
    /*This is a kind of configuration. After the game configuration management is designed, there will be no
      no need of this func. probably. This func. adds an equipment slot for each slot type
    */
    public void addEquipmentSlots()
    {
        EquipmentSlot equipmentSlot = new EquipmentSlot();
        equipmentSlot.setSlotType(SlotType.WEAPON);//just weapon created for now
        for (int i = 0; i < equipmentRendererPair.Length; i++)
        {
            if(equipmentRendererPair[i].slotType == SlotType.WEAPON)
            {
                equipmentRendererPair[i].equipmentSlot = equipmentSlot;
                break;
            }
        }
    }
    public EquipmentRendererMap[] getEquipmentRendererPairs()
    {
        return equipmentRendererPair;
    }
    public SpriteRenderer getRendererBySlotType(SlotType slotType)
    {
        for (int i = 0; i < equipmentRendererPair.Length; i++)
        {
            if(equipmentRendererPair[i].slotType == slotType)
            {
                return equipmentRendererPair[i].renderer;
            }
        }
        return null;
    }
}
