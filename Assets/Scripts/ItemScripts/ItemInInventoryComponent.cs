using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script is attached to each item in inventory. Keeps item,button,image pairs. If an object
  carrying this object
*/
public class ItemInInventoryComponent : MonoBehaviour
{
    private ConsumableItem item;
    private Button itemButton;
    private Image itemImage;
    void Awake()
    {
        itemButton = GetComponent<Button>();
        itemImage = GetComponent<Image>();
    }
    public void setItem(ConsumableItem item)
    {
        this.item = item;
        ChangeSprite();
    }
    public ConsumableItem getItem()
    {
        return this.item;
    }
    private void ChangeSprite()
    {
        Sprite s = Sprite.Create(item.getTexture(), 
            new Rect(0.0f, 0.0f, item.getTexture().width, item.getTexture().height), 
                new Vector2(0.5f, 0.5f), 100.0f);
        itemImage.sprite = s;
    }
}
