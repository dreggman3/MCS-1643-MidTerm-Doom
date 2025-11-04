using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameRestart : MonoBehaviour
{
    public Button restartButton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            restartButton.onClick.Invoke();
        }
    }
}