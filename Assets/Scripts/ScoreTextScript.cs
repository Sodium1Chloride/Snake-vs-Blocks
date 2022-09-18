using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextScript : MonoBehaviour
{
    public LevelMaster LevelMaster;
    public TextMeshProUGUI Text;
    void Update()
    {
        Text.SetText(LevelMaster.Score.ToString());
    }
}
