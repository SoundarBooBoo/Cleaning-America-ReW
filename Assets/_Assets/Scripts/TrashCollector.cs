using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    public Transform TrashHolder;
    //public GameObject Dumpholder;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            Trash trash = other.GetComponent<Trash>();
            trash.CollectTrash(TrashHolder);
            Debug.Log("Trash...");
        }
    }

   
}
