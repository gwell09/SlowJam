using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueStarter : MonoBehaviour
{
    private DialogueRunner runner;

    // Start is called before the first frame update
    void Start()
    {
        runner = FindObjectOfType<DialogueRunner>();
        runner.StartDialogue(GameManager.Instance.currentNode);
    }
}
