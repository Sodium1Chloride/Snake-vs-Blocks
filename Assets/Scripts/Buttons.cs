using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public LevelMaster LevelMaster;
    public Transform GameUI;


    public void StartGame()
    {
        GameUIOn();
        LevelMaster.SetLevelMovement(true);
        LevelMaster.ChangeMusic("Game");

    }

    public void RestartGame()
    {
        GameUIOn();
        LevelMaster.RestartGame();
        LevelMaster.ChangeMusic("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameUIOn()
    {
        transform.parent.gameObject.SetActive(false);
        GameUI.gameObject.SetActive(true);
    }
}
