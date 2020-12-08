


/*
This script used to using to items and its textures.But now,Item class keeps the Texture as a property
instead of this map.
*/
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//
//[System.Serializable]
//public struct ItemTexturePairs
//{
//    public string itemName;
//    public Texture2D itemTexture;
//}
//[CreateAssetMenu(menuName= "ScriptableObjects/ItemTexturePairs",fileName= "ItemTexturePairs")]
//public class ItemTextureMap : ScriptableObject
//{
//    [SerializeField] private  ItemTexturePairs[] itemTexturePairs;
//    public  Texture2D getTextureOfItem(string itemName)
//    {
//        Texture2D chosenTexture = null;
//        for(int i = 0; i< itemTexturePairs.Length;i++)
//        {
//            if(itemTexturePairs[i].itemName == itemName)
//            {
//                chosenTexture = itemTexturePairs[i].itemTexture;
//                break;
//            }
//        }
//        return chosenTexture;
//    }
//}
