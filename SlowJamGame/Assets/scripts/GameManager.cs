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

    public string currentNode = "1_customer";
    public string nextNode; // should be set when going to a minigame


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

    public void StoreNextNode(string node)
    {
        nextNode = node;
    }

    public void GoToNextDay()
    {
        currentDay++;
        currentNode = nextNode;
        ChangeScene.Instance.LoadScene("MAIN");
    }
    public void GoBackToNarrative()
    {
        currentNode = nextNode;
        ChangeScene.Instance.LoadScene("MAIN");
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