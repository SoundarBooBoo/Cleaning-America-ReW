using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrashCollector : MonoBehaviour
{
    public Slider levelProgressSlider;
    public Transform TrashHolder;
    //public GameObject Dumpholder;
    public Transform trashParentInScene;

    [SerializeField]
    TextMeshProUGUI levelProgressTextTM;

    private int totalTrashCount;
    private int collectedTrashCount;

    public float percntg;


    private void Start()
    {
        totalTrashCount = trashParentInScene.childCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            Trash trash = other.GetComponent<Trash>();
            trash?.CollectTrash(TrashHolder);
            Debug.Log("Trash...");
            collectedTrashCount++;

            percntg = (float)collectedTrashCount / totalTrashCount;

            levelProgressSlider.value = percntg;
            levelProgressTextTM.text = (Mathf.Clamp(percntg,0,1) * 100f).ToString(format: "00.00") + "%";
            if (percntg == 0.98f)
            {
                Debug.Log("Almost collected");

            }
        }
    }

   
}
