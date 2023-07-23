using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;

public class PlaySoundCommand : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component that will play the sound
    public DialogueRunner dialogueRunner;

    public void PlaySound(string bell)
    {
        // Load the sound clip from Resources folder
        AudioClip soundClip = Resources.Load<AudioClip>(bell);

        if (soundClip != null)
        {
            // Play the sound effect
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogWarning($"Sound clip '{bell}' not found in assets folder.");
        }
    }
}