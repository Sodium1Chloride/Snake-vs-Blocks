using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public LevelMaster LevelMaster;
    public Transform LevelTransform;
    public Slider Slider;
    public TextMeshProUGUI LevelNow;
    public TextMeshProUGUI LevelNext;

    void Update()
    {
        Slider.value = LevelTransform.position.z / -LevelMaster.LengthOfLevel;
    }

    public void UpdateLevelNumber(int value)
    {
        LevelNow.SetText(value.ToString());
        LevelNext.SetText((value + 1).ToString());

    }

}
