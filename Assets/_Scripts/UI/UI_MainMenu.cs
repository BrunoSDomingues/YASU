using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    GameManager gm;
    public GameObject player;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void StartGame()
    {
        player = GameObject.FindWithTag("player");
        player.SetActive(true);
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
