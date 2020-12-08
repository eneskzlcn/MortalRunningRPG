using UnityEngine;

//Every Item has a name and a texture simply. Everything interactable in game is implementing from IItem class
//
public abstract class IItem: ScriptableObject
{
    [SerializeField] protected string name;
    [SerializeField] protected Texture2D texture;


    public abstract string getName();
    public abstract Texture2D getTexture();
}
