using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the Hacking minigame. Holds all the wordpuzzles and calls functions to make sure 
/// the game is being properly managed
/// </summary>
public class WordPuzzleManager : MonoBehaviour
{
    [SerializeField] 
    private List<WordPuzzle> wordPuzzles; // collection of wordpuzzles to be dragged in

    [SerializeField]
    private PuzzleViewer viewer; // the script that's in charge of the UI

    public WordPuzzle currentWordPuzzle; // current WordPuzzle we're decoding/unscrambling

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomWordPuzzle(GameManager.Instance.CurrentDay.wordPuzzles); 
    }

    public void ChooseRandomWordPuzzle(List<WordPuzzle> puzzles)
    {
        if (puzzles.Count == 0)
        {
            Debug.LogError("The word puzzle list in WordPuzzleManager is empty or all the puzzles are completed.\nReturning...");
            return;
        }

        int randNum = Random.Range(0, puzzles.Count);
        WordPuzzle puzzle = puzzles[randNum]; // getting our random puzzle :3

        if (puzzle != null && puzzle.isPuzzleCompleted)
        {
            puzzles.Remove(puzzle);
            ChooseRandomWordPuzzle(puzzles); // keep looking for a puzzle that hasn't already been completed!
        }
        else
        {
            currentWordPuzzle = puzzle;
            viewer.SetScrambledText(currentWordPuzzle.GetScrambledWord()); // show our scrambled word!
        }
    }

    public bool isDayComplete() // hacking happens at the end of the day
    {
        foreach(WordPuzzle w in GameManager.Instance.CurrentDay.wordPuzzles)
        {
            if(!w.isPuzzleCompleted) // all wordpuzzles must be complete
            {
                return false;
            }
        }
        return true;
    }


    /// <summary>
    /// Chooses a random puzzle from our wordPuzzles list. Won't choose a puzzle we completed
    /// </summary>
    public void ChooseRandomWordPuzzle()
    {
        if(wordPuzzles.Count == 0)
        {
            Debug.LogError("The word puzzle list in WordPuzzleManager is empty or all the puzzles are completed.\nReturning...");
            return;
        }

        int randNum = Random.Range(0, wordPuzzles.Count); 
        WordPuzzle puzzle = wordPuzzles[randNum]; // getting our random puzzle :3

        if(puzzle != null && puzzle.isPuzzleCompleted ) 
        { 
            wordPuzzles.Remove(puzzle);
            ChooseRandomWordPuzzle(); // keep looking for a puzzle that hasn't already been completed!
        }
        else
        {
            currentWordPuzzle = puzzle;
            viewer.SetScrambledText(currentWordPuzzle.GetScrambledWord()); // show our scrambled word!
        }
    }

    /// <summary>
    /// Trigger by pressing the submit ui button. If the descrambled word is incorrect, we will clear the input 
    /// </summary>
    public void SubmitPlayerInput()
    {
        bool isCorrect = currentWordPuzzle.isCodeMatching(viewer.playerInput);

        if(isCorrect)
        {
            Debug.Log("<color=green>Correct!</color>");
            currentWordPuzzle.isPuzzleCompleted = true;

            if(isDayComplete())
            {
                GameManager.Instance.GoToNextDay();
            }
            else
            {
                ChooseRandomWordPuzzle(GameManager.Instance.CurrentDay.wordPuzzles);
            }
        }
        else
        {
            viewer.ClearInput();
            Debug.Log("<color=red>Wrong!</color>");
        }
    }
}
