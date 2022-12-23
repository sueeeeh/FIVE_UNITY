using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby_manager : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("lobby");
    }
}
