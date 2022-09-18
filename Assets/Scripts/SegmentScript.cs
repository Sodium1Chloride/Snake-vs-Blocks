using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public bool First;
    public GameObject Cube;
    public GameObject Bonus;
    public GameObject thisObject;
    public Transform Plane;
    public PlayerVariables PlayerVariables;

    private float[] _xPositions = new float[4] { -7.5f, -2.5f, 2.5f, 7.5f };
    private int _cubesNumber;
    private int _bonusNumber;
    private List<Vector3> _spawned = new();
    private float _X;
    private float _Z;
    private Vector3 currentPosition;
    private CubeGenerator CubeGenerator;

    public void GenerateAll()
    {
        if (First == true)
            return;
        ClearAll();
        _cubesNumber = Random.Range(1, 3);
        GenerateSomething(Cube, _cubesNumber);
        _bonusNumber = Random.Range(1, 3);
        GenerateSomething(Bonus, _bonusNumber);
    }

    private void GeneratePositions()
    {
        _X = _xPositions[Random.Range(0, _xPositions.Length)];
        _Z = _xPositions[Random.Range(0, _xPositions.Length)];
    }

    private void ClearAll()
    {
        Transform[] childrens = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < childrens.Length; i++)
        {
            if (childrens[i].gameObject.CompareTag("Cube") | childrens[i].gameObject.CompareTag("Bonus"))
            {
                Destroy(childrens[i].gameObject);
            }
        }
    }

    private void GenerateSomething(GameObject something, int numberOfSomething)
    {
        for (int i = 0; i < numberOfSomething; i++)
        {
            GameObject spawnedSomething = Instantiate(something, Plane);
            GeneratePositions();
            currentPosition = new Vector3(_X, 2.5f, _Z);
            if (_spawned.Count == 0)
            {
            }
            else
            {
                for (int j = 0; j < _spawned.Count; j++)
                {
                    if (_spawned[j] != currentPosition)
                    {
                        continue;
                    }
                    GeneratePositions();
                    currentPosition = new Vector3(_X, 2.5f, _Z);
                    j--;
                }
            }

            spawnedSomething.transform.localPosition = currentPosition;
            if(spawnedSomething.TryGetComponent(out CubeGenerator))
            {
                BasedOnPlayerHP(CubeGenerator);
            }
            _spawned.Add(currentPosition);
        }
    }

    public void GenerateCubeRow()
    {
        ClearAll();
        float xposition = -7.5f;
        for (int i = 0; i < 4; i++)
        {
            GameObject cube = Instantiate(Cube, Plane);
            cube.transform.localPosition = new Vector3(xposition, 2.5f, 2.5f);
            BasedOnPlayerHP(cube.GetComponent<CubeGenerator>());
            xposition += 5f;
        }
    }

    private void BasedOnPlayerHP(CubeGenerator script)
    {
        script.HP = Mathf.Clamp(Random.Range(PlayerVariables.PlayerLength - 10, PlayerVariables.PlayerLength + 10), 1, 100);
        script.Initialize();
    }
}
