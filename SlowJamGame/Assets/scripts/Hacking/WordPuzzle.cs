using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Scriptable Object that contains the function for scrambling the word, checking if the player's word matches,
/// and the actual word that's going to be scrambled
/// </summary>
[CreateAssetMenu(fileName ="wordpuzzle",menuName ="SO/word puzzle",order = 0)]
public class WordPuzzle : ScriptableObject
{
    [Tooltip("This is the word that the player should have at the end of the puzzle")]
    [SerializeField]
    private string endingCode;

    public bool isPuzzleCompleted; 


    /// <summary>
    /// Checking to see if the code the player input matches the intended unscrambled word
    /// </summary>
    /// <param name="code">The player's input</param>
    /// <returns>Boolean if the codes actually match</returns>
    public bool isCodeMatching(string code)
    {
        // making sure the strings don't have weird capitalizations or any empty spaces that can accidentally return this as false
        // while it's actually set to true
        return string.Equals(endingCode.ToLower().Trim(),code.ToLower().Trim());
    }

    /// <summary>
    /// Scrambles the endingCode in the WordPuzzle scriptable object
    /// </summary>
    /// <returns>String created by scrambling the WordPuzzle's ending code</returns>
    public string GetScrambledWord()
    {
        List<char> word = endingCode.ToCharArray().ToList(); // splitting our word / desired endingCode into characters
        string scrambledWord = ""; // starting our scrambledWord so that it's empty

        while (word.Count > 0) // As long as we have letters left to grab from the word...
        {
            int indexChar = Random.Range(0, word.Count); //Get a random number based off the the current characters in the word...
            scrambledWord += word[indexChar]; //Add that random letter to our scrambled word...
            word.RemoveAt(indexChar); // And remove the letter from our og word list so that it's not reused!
        }
        return scrambledWord;
    }
}
