using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public int CurrentHP;
    public int HP;
    public int MinHP;
    public int MaxHP;
    public TextMeshPro HPText;
    public Renderer Render;

    private void Update()
    {
        HPText.text = CurrentHP.ToString();
    }

    public void DestroyMe()
    {
        Destroy(transform.gameObject);
    }

    public void Initialize()
    {
        CurrentHP = HP;
        Render.material.SetFloat("_Position", HP / 100f);
    }
}
