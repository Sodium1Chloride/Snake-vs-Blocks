using TMPro;
using UnityEngine;

public class WinScreenScript : MonoBehaviour
{
    public LevelMaster LevelMaster;
    public TextMeshProUGUI LevelNumberText;

    private void OnEnable()
    {
        LevelNumberText.SetText("Level " + LevelMaster.LevelNumber + " Complete!");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelMaster.SetLevelMovement(true);
            transform.gameObject.SetActive(false);
            LevelMaster.ChangeMusic("Game");
        }
    }
}
