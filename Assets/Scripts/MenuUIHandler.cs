using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public Input NameInput;

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void UpdateName (string playerName) {
        Debug.Log("Updated name: " + playerName);
        MenuManager.PlayerName = playerName;
    }
}