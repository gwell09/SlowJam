using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// PuzzleViewer contains all the UI bits needed for the WordPuzzleManager to work
/// </summary>
public class PuzzleViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scrambledWordText; // the displayed scrambled word

    [SerializeField]
    private TMP_InputField playerInputField; // the input field for the player to try and descramble the word
    public string playerInput { get {  return playerInputField.text; } } // get only variable getting the player's input

    /// <summary>
    /// Clears the player's input in the input field
    /// </summary>
    public void ClearInput()
    {
        playerInputField.text = string.Empty;
    }


    /// <summary>
    /// Sets the scrambledWordText to the given text
    /// </summary>
    /// <param name="text">the text scrambledWordText is set to</param>
    public void SetScrambledText(string text)
    {
        scrambledWordText.text = text;
    }
}
