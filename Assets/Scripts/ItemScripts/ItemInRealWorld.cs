using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script is attached to items in game world (any item in world except inventory items)
    Every object carrying this item is accepted as an item got put into game world.
*/
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class ItemInRealWorld : MonoBehaviour
{
    [SerializeField] private IItem item;
    private SpriteRenderer itemInRealWorldSprite;
    private void Awake()
    {
        itemInRealWorldSprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        changeSprite();
    }
    public void setItem(IItem item)
    {
        this.item = item;
    }
    private void changeSprite()
    {
        Sprite s = Sprite.Create(item.getTexture(), 
        new Rect(0.0f, 0.0f, item.getTexture().width, item.getTexture().height), new Vector2(0.5f, 0.5f), 100.0f);
        itemInRealWorldSprite.sprite = s;
    }
    public IItem getItem()
    {
        return this.item;
    }
}
