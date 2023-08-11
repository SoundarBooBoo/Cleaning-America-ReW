using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum LayerAnimationDirection
{
    Left,Rigth,Top,Bottom
}
public class AnimateLayers : MonoBehaviour
{
    [SerializeField]
    Transform currentLevelT;


    Vector3 direction;
    

    public float delay = 1.5f;

    public float power= 8f;


    private void Start()
    {
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(delay);

        direction = (currentLevelT.position - transform.position).normalized;

        transform.DOMove(transform.position - direction * power , 1.5f).SetEase(Ease.InOutExpo);
        
    }

}
