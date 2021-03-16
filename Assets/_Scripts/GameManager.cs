using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, ENDGAME };
    public GameState gameState { get; private set; }
    public int playerHealth;
    public int points;
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        playerHealth = 20;
        points = 0;
        gameState = GameState.MENU;
    }


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        if (nextState == GameState.GAME)
        {
            Reset();
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        playerHealth = 20;
        points = 0;
    }
}