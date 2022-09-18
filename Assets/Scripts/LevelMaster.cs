using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMaster : MonoBehaviour
{
    public GameObject Segment;
    public GameObject Finish;
    public Player Player;
    public LevelMovement LevelMovement;
    public Transform MainMenu;
    public Transform LoseMenu;
    public Transform WinUI;
    public float LengthOfLevel;
    public int LevelNumber = 0;
    public SliderScript Slider;
    public int Score = 0;
    public AudioSource AudioSource;
    public AudioClip GameMusic;
    public AudioClip MenuMusic;
    
    private int _numberOfSegments;
    private PlayerVariables _playerVariables;

    void Start()
    {
        _playerVariables = Player.PlayerInfo;
        Generate();
        MainMenu.gameObject.SetActive(true);
    }


    public void Generate()
    {
        ResetLevel();
        SetLevelMovement(false);
        _numberOfSegments = Random.Range(10, 15);
        for (int i = -1; i<_numberOfSegments; i++)
        {
            GameObject _currentSegment = Instantiate(Segment, transform);
            _currentSegment.transform.localPosition = new Vector3(0, 0, 10 + (20 * i));
            SegmentScript segmentScript = _currentSegment.GetComponent<SegmentScript>();
            segmentScript.PlayerVariables = _playerVariables;
            if (i > 0)
                if (i % 5 == 0) 
                    segmentScript.GenerateCubeRow();
                else
                    segmentScript.GenerateAll();


            if (i == (_numberOfSegments - 1))
            {
                _currentSegment = Instantiate(Finish, transform);
                FinishScript script = _currentSegment.GetComponent<FinishScript>();
                script.WinUI = WinUI;
                script.LevelMaster = this;
                _currentSegment.transform.localPosition = new Vector3(0, 0, 10 + (20 * (i+1)));
            }

        }
        LengthOfLevel = _numberOfSegments * 20;
        LevelNumber++;
        Slider.UpdateLevelNumber(LevelNumber);
    }

    public void SetLevelMovement(bool value)
    {
        LevelMovement.enabled = value;
        Player.CanMove = value;
    }

    public void ChangeMusic(string value)
    {
        float currentTime = AudioSource.time;
        AudioSource.Stop(); 
        AudioSource.clip = value == "Menu" ? MenuMusic : GameMusic;
        AudioSource.time = currentTime;
        AudioSource.Play();
    }

    public void LoseGame()
    {
        SetLevelMovement(false);
        LoseMenu.gameObject.SetActive(true);
        ChangeMusic("Menu");
        Score = 0;
        LevelNumber = 0;
    }

    public void ResetLevel()
    {
        Transform[] segments = transform.GetComponentsInChildren<Transform>();
        for (int i = 1; i<segments.Length; i++)
        {
            Destroy(segments[i].gameObject);
        }
        transform.position = new Vector3(0, 0, -10f);
        LevelMovement.enabled = false;
    }

    public void RestartGame()
    {
        Player.SetLengthBack();
        Generate();
        SetLevelMovement(true);
    }
}
