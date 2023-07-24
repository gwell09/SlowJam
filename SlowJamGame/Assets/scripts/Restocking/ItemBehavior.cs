using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public Item item;
    public GameObject itemPrefab;

    private ClickableSprite clickable;
    private CursorFollower follower;

    private void Start()
    {
        follower = GetComponent<CursorFollower>();
        clickable = GetComponent<ClickableSprite>();
    }
    public void SpawnAtInit()
    {
       GameObject g = Instantiate(itemPrefab,transform.position,Quaternion.identity);
       ItemBehavior i = g.GetComponent<ItemBehavior>();
       i.item = item;
       g.name = item.ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<ItemChecker>()!= null)
        {
            ItemChecker checker = collision.GetComponent<ItemChecker>();
            if (clickable.interactable && !clickable.isCursorDown)
            {
                if (checker.ContainsCorrectKey(item))
                {
                    clickable.interactable = false;
                    clickable.enabled = false;
                    this.enabled = false;
                    follower.shouldFollowCursor = false;
                    checker.CheckForCompletion();
                }
            }
        }
    }
}
public enum Item
{
    lightbulb = 0,
    highVoltBattery = 1,
    lowVoltBattery = 2,
    motherboard = 3,
    oil= 4,
    peanutbutter=5,
    soda = 6,
    twink= 7,
    sock =8

     //added more
}