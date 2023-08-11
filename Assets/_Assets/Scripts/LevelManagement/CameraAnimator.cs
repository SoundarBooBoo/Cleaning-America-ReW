using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    [SerializeField]
    Transform camZoomedInTransform;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return  new WaitForSeconds(3f);

        transform.DOMove(camZoomedInTransform.position,1.5f);
        transform.DORotateQuaternion(camZoomedInTransform.rotation,2f);
    }
}
