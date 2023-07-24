using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public Item item;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAtInit()
    {
       GameObject g = Instantiate(itemPrefab,transform.position,Quaternion.identity);
       ItemBehavior i = g.GetComponent<ItemBehavior>();
       i.item = item;
       g.name = item.ToString();
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