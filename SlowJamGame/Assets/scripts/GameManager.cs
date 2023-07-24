using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private Day[] days; // days should be set up in the inspector
    public Day[] Days { get { return days; } } // shouldn't be able to set days via the script. Only get them.

    public int currentDay;

    public Day CurrentDay => days[currentDay];


    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        if(Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Day
{
    public int num; // what day is it?
    public List<WordPuzzle> wordPuzzles; //what wordpuzzles need solving?
    public RestockItems[] items; // what needs restocking?

    public string postPuzzleNode; //Node to go to after doing puzzles
    public string postRestockNode; //Node to go to after doing restocking
}

[System.Serializable]
public class RestockItems

{
    public Item item;
    public int itemNum;
}