using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckVisual : MonoBehaviour
{
    public TruckController controller;

    [SerializeField]
    private float offset = 0.01f;
    private void Update()
    {
        transform.position = controller.transform.position + controller.targetDirection.normalized * -offset;
         
    }
}
