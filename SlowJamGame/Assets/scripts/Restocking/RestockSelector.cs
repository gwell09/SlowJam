using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RestockSelector : MonoBehaviour
{
    [SerializeField]
    private int maxShelfItems = 6;

    private int itemsToSelect;

    public int currentItemsRetocked;

    [SerializeField]
    private TextMeshProUGUI restockText;

    public Dictionary<Item,int> selectedItems;

    public Item firstKey, secondKey, thirdKey;

    // Start is called before the first frame update
    void Awake()
    {
        selectedItems = new Dictionary<Item,int>();
        SelectItems();
    }

    public void SelectItems()
    {
        string restockInstructions = "We need ";

        itemsToSelect = maxShelfItems;
        Item itemType = (Item) Random.Range(0, 4);
        int numOfItems = GetRestockNum();

        restockInstructions += numOfItems.ToString() + " " + itemType.ToString();


        itemsToSelect -= numOfItems;

        selectedItems.Add(itemType, numOfItems);
        firstKey = itemType;

        //NOTE: This is a lil messy because any repeated code should just be in a function to be called
        // but I'm lazy -Geneva

        //TODO: Adhere to the note and make it a function so the same item type doesn't get added to the dict twice -Gen
        if(itemsToSelect > 0 )
        {
            itemType = (Item)Random.Range(0, 4);
            numOfItems = GetRestockNum();

            restockInstructions += " and " + numOfItems.ToString() + " " + itemType.ToString();


            itemsToSelect -= numOfItems;
            selectedItems.Add(itemType, numOfItems);
            secondKey = itemType;

            if (itemsToSelect > 0)
            {
                itemType = (Item)Random.Range(0, 4);
                numOfItems = itemsToSelect;

                restockInstructions += " and " + numOfItems.ToString() + " " + itemType.ToString();
                selectedItems.Add(itemType, numOfItems);
                thirdKey = itemType;
            }
        }

        restockText.text = restockInstructions;

    }


    public int GetRestockNum()
    {
        return Random.Range(1, itemsToSelect + 1);
    }
}
