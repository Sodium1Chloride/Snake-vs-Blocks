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


    private List<Material> _material = new();

    // Start is called before the first frame update


    private void Update()
    {
        HPText.text = CurrentHP.ToString();
    }

    public void DestroyMe()
    {
        Destroy(transform.gameObject);
    }

    public void Generate()
    {
        HP = Random.Range(1, 5);
        CurrentHP = HP;
        Render.GetMaterials(_material);
        _material[0].SetFloat("_Position", HP / 100f);
        Render.sharedMaterial = _material[0];
    }

    public void Initialize()
    {
        CurrentHP = HP;
        Render.GetMaterials(_material);
        _material[0].SetFloat("_Position", HP / 100f);
        Render.sharedMaterial = _material[0];
    }
}
