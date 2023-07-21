using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChecker : MonoBehaviour
{
    [SerializeField]
    private RestockSelector restockSelector;

    public static int firstNeededNum, secondNeededNum, thirdNeededNum;

    // Start is called before the first frame update
    void Start()
    {
        if(restockSelector.selectedItems.Count >= 1)
        {
            firstNeededNum = restockSelector.selectedItems[restockSelector.firstKey];
        }
        if (restockSelector.selectedItems.Count >= 2)
        {
            secondNeededNum = restockSelector.selectedItems[restockSelector.secondKey];
        }
        if (restockSelector.selectedItems.Count == 3)
        {
            thirdNeededNum = restockSelector.selectedItems[restockSelector.thirdKey];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            ClickableSprite clickable = other.GetComponent<ClickableSprite>();
            if (clickable != null) 
            {
                ItemBehavior item = other.GetComponent<ItemBehavior>(); 
                CursorFollower follower = other.GetComponent<CursorFollower>(); 
                if(ContainsCorrectKey(item.item))
                {
                    clickable.interactable = false;
                    follower.shouldFollowCursor = false;
                    if(restockSelector.selectedItems.Count == 0)
                    {
                        Debug.Log("<color=green>Done!</color>");
                    }
                }
            }
        }
    }

    public bool ContainsCorrectKey(Item item)
    {
        if (!restockSelector.selectedItems.ContainsKey(item)) return false;

        if (restockSelector.firstKey == item)
        {
            firstNeededNum -= 1;
            if(firstNeededNum == 0)
            {
                restockSelector.selectedItems.Remove(item);
            }
            return true;
        }
        if (restockSelector.secondKey == item)
        {
            secondNeededNum -= 1;
            if (secondNeededNum == 0)
            {
                restockSelector.selectedItems.Remove(item);
            }
            return true;
        }
        if (restockSelector.thirdKey == item)
        {
            thirdNeededNum -= 1;
            if (thirdNeededNum == 0)
            {
                restockSelector.selectedItems.Remove(item);
            }
            return true;
        }
        return false;
    }
}
