using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public LevelMaster LevelMaster;
    public Transform WinUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Head"))
        {
            LevelMaster.Generate();
            WinUI.gameObject.SetActive(true);
        }
    }
}
