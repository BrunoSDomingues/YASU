using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public Text message;
    public GameObject player;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.playerHealth <= 0)
        {
            message.text = "You scored " + gm.points + " points!";
        }
        else if (gm.points >= 5000)
        {
            message.text = "YOU WIN!";
        }
    }

    public void NewGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void ExitGame()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
