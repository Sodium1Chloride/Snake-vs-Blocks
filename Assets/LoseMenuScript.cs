using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseMenuScript : MonoBehaviour
{

    public LevelMaster Player;
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Score.SetText("Your Score: " + Player.Score.ToString());
    }
}
