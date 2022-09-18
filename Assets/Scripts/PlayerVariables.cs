using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public int PlayerLength;
    public Transform PlayerHead;
    public List<GameObject> Body;
    public int CurrentLength = 1;
    public GameObject BodyPiece;
    public float Speed;
    public float MinSpeed;
    public LevelMaster LevelMaster;
    public TextMeshPro LengthText;

    private GameObject _previousPiece;
    private GameObject _currentPiece;
    private void Start()
    {
        _previousPiece = PlayerHead.gameObject;
        AddLength();
    }



    public void AddLength()
    {
        for (int i = CurrentLength; i < PlayerLength; i++)
        {
            if (i > 0)
                _previousPiece = Body[i - 1];
            GameObject currentPiece = Instantiate(BodyPiece, transform);
            currentPiece.transform.position = _previousPiece.transform.position + new Vector3(0, 0, -2 * (i + 1));
            Renderer pieceRenderer = currentPiece.GetComponent<Renderer>();
            pieceRenderer.material.SetFloat("_Position", 1f - ((float)CurrentLength / 10));
            BodyScript bodyScript = currentPiece.GetComponent<BodyScript>();
            bodyScript.ObjectBefore = _previousPiece.transform;
            Body.Add(currentPiece);
            CurrentLength++;
        }
        UpdateText();
    }

    public void RemovePieceOfBody()
    {
        if (Body.Count == 0)
        {
            PlayerHead.gameObject.SetActive(false);
            LevelMaster.LoseGame();
            return;
        }
        _currentPiece = Body[CurrentLength - 1];
        Body.RemoveAt(CurrentLength - 1);
        Destroy(_currentPiece);
        CurrentLength--;
        PlayerLength--;
        if (Body.Count == 0)
        {
            _previousPiece = PlayerHead.gameObject;
        }
        UpdateText();
    }

    public void AddScore(int value)
    {
        LevelMaster.Score += value;

    }

    public void UpdateText()
    {
        LengthText.SetText((PlayerLength + 1).ToString());
    }

}
