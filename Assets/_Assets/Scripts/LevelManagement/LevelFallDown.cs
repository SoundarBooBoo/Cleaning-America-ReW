using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Globalization;

public class LevelFallDown : MonoBehaviour
{
    public Transform WallsIn;
    public Transform WallsOut;
    public Transform Base;    
    public Transform Road;
    public Transform Name;
    public Transform DirtLayer;

    public Transform TrashT;


    Vector3 wallInPos,basePos,dirtPos,roadPos,namePos,wallOutPos,trashPos;

    public float fallDelay = 0.2f;
    public float fallDuration = 2f;

    private void Start()
    {

        wallInPos = WallsIn.transform.position;
        wallOutPos = WallsOut.transform.position;
        basePos = Base.transform.position;
        dirtPos = DirtLayer.transform.position;
        roadPos = Road.transform.position;
        namePos = Name.transform.position;
        trashPos = TrashT.transform.position;

        WallsIn.transform.position += transform.up * 4f;
        WallsOut.transform.position += transform.up * 4f;
        Base.transform.position += transform.up * 4f;
        DirtLayer.transform.position += transform.up * 4f;
        Road.transform.position += transform.up * 4f;
        Name.transform.position += transform.up * 4f;
        TrashT.transform.position += transform.up * 4f;

        StartCoroutine(StartFall());
    }

    IEnumerator StartFall()
    {
        yield return new WaitForSeconds(0.5f);

        Base.DOMove(basePos, fallDuration).SetEase(Ease.OutQuint);

        yield return new WaitForSeconds(fallDelay);

        WallsIn.DOMove(wallInPos , fallDuration).SetEase(Ease.OutQuint);

        yield return new WaitForSeconds(fallDelay);

        WallsOut.DOMove(wallOutPos ,fallDuration).SetEase(Ease.OutQuint);   

        yield return new WaitForSeconds(fallDelay);

        Road.DOMove(roadPos , fallDuration).SetEase(Ease.OutQuint);

        yield return new WaitForSeconds(fallDelay);

        DirtLayer.DOMove(dirtPos, fallDuration).SetEase(Ease.OutQuint);

        yield return new WaitForSeconds(fallDelay);

        TrashT.DOMove(trashPos , fallDuration).SetEase(Ease.OutQuint);

        yield return new WaitForSeconds (fallDelay);

        Name.DOMove(namePos, fallDuration).SetEase(Ease.OutQuint);

    }

}
