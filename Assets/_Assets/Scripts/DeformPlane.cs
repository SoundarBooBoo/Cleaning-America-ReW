using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeformPlane : MonoBehaviour
{
    MeshFilter meshFilter = new MeshFilter();

    Mesh planeMesh;

    Vector3[] verts;


    [SerializeField]
    Transform deformT;

    [SerializeField]
    TruckController controller;

    [SerializeField]
    float Radius;
    [SerializeField]
    float Power;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        planeMesh = meshFilter.mesh;
        verts = planeMesh.vertices;
    }

    private void Update()
    {
        if (!controller.canProcessInput)
        {
            DeformThisPlane(deformT.position);
        }
    }

    void DeformThisPlane(Vector3 positionToDeform)
    {
        
        positionToDeform = transform.InverseTransformPoint(positionToDeform);

        for (int i = 0; i < verts.Length; i++)
        {
            float distance = (verts[i]- positionToDeform).sqrMagnitude;
            
            if(distance < Radius)
            {
                verts[i] -= Vector3.up * Power;
            }
        }
        
        planeMesh.vertices = verts;
    }
}
