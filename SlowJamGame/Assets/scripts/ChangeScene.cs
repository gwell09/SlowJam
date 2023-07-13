using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    void OnTriggerEnter()
    {


        SceneManager.LoadScene(nextSceneName);
        Debug.Log("work");

    }
}