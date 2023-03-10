using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public string labelText = "Collect all 6 items to complete the stage.";

    public bool showLossScreen = false;

    public int maxItems = 6;
    private int _itemsCollected = 0;

    public int airJumpCount = 0;

    public int platformsRemaining = 0;
    public bool platformTrigger;
    public int Items
    {
        get { return _itemsCollected; }
        set {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";

                showWinScreen = true;

                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }
    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }
        set{
            _playerHP = value;
            Debug.LogFormat("Lives:{0}", _playerHP);
        
            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
                
            } else
            {
                labelText = "Ouch... that's got to hurt.";
            }     
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected:" + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                RestartLevel();
            }
        
        }

        if (platformTrigger)
        {
            GUI.Box(new Rect(Screen.width / 2 + 50, Screen.height / 2 - 25, 100, 25), "Platforms: " + platformsRemaining);
        }
        
        if (airJumpCount > 0)
        {
            GUI.Box(new Rect(Screen.width / 2 - 175, Screen.height / 2 - 25, 125, 25), "AirJump Count: " + airJumpCount);
        }

        if (showLossScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "You lose..."))
            {
                RestartLevel();
            }
        }
    }
}
