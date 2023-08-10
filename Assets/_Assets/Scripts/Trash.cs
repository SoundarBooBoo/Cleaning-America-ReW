using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectTrash(Transform Parent)
    {
        transform.DOMoveY(2f, 0.1f).SetEase(Ease.InBounce);
        transform.DOMove(Parent.position, 0.1f).SetEase(Ease.InBounce).OnComplete(()=> {
            transform.localPosition = Vector3.zero;
        });
        transform.SetParent(Parent);
        transform.DOScale(new Vector3(0.25f, 0.25f, 0.25f), 0.2f);
    }
}
