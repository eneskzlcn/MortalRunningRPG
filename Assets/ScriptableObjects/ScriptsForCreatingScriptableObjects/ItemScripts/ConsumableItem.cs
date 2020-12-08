using UnityEngine;

/*
    A ConsumableItem is a usable item that should be kept in inventory.
*/
public abstract class ConsumableItem :IItem
{
    public override Texture2D getTexture()
    {
        return this.texture;
    }
    public abstract void consume();
    
}
