using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ScannableSpawner : MonoBehaviour
{
    public bool isComplete;
    public GameObject scannablePrefab;

    public List<ScannableItem> scannables;

    [SerializeField]
    private GameObject scannableHolder;
    // Start is called before the first frame update
    void Start()
    {
        scannables = new List<ScannableItem>();
    }


    public bool isScanningComplete() // hacking happens at the end of the day
    {
        foreach (ScannableItem i in scannables)
        {
            if (!i.wasScanned) // all wordpuzzles must be complete
            {
                return false;
            }
        }
        isComplete = true;
        scannables.Clear();
        return true;
    }

    [YarnCommand("checkout")]
    public IEnumerator CheckOut(string itemName, int amt = 1)
    {
        Item item;
        Enum.TryParse<Item>(itemName, out item);
        if (scannables.Count == 0)
        {
            scannableHolder.SetActive(true);
            for (int i = 0; i < amt; i++)
            {
                GameObject g = Instantiate(scannablePrefab,scannableHolder.transform);
                ScannableItem s = g.GetComponent<ScannableItem>();
                s.item = item;
                scannables.Add(s);
            }
        }

        yield return new WaitForSeconds(6);
    }
}