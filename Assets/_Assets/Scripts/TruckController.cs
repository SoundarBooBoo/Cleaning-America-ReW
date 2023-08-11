
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class TruckController : MonoBehaviour
{
    public TruckMovePoints truckPoint;

    public Transform truckVisual;

    public Vector3 targetDirection;

    public ParticleSystem smokeEffect;

    [SerializeField]
    Transform FillObjectT;

    [SerializeField]
    GameObject boundingBox;

    [SerializeField]
    EffectObject effectObject;

    [SerializeField]
    Transform effectCloneParent;

    [SerializeField]
    float moveSpeed = 1f;

    [HideInInspector]
    public bool canProcessInput;


    private Bounds bounds;
    private EffectObject[] effectObjects;


    

    private void Start()
    {
        transform.position = truckPoint.transform.position;
        canProcessInput = true;
        bounds = boundingBox.GetComponent<BoxCollider>().bounds;

        //IntializePool();

    }

    void IntializePool()
    {
        effectObjects = new EffectObject[10];
        for (int i = 0; i < 10; i++)
        {
            Vector3 rPos = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
            
            effectObjects[i] = Instantiate(effectObject, rPos, Quaternion.identity);
            effectObjects[i].transform.SetParent(effectCloneParent, true);
        }
    }

    IEnumerator DoCollectingEffect()
    {
        foreach (EffectObject obj in effectObjects)
        {
            if(obj!= null)
            {
                if(!obj.isOn)
                {
                    obj.transform.DOMove(Vector3.up*6f, 1f).SetEase(Ease.InOutBounce);
                    obj.transform.DOMove(effectCloneParent.transform.position, 1f).SetEase(Ease.InOutBounce).OnComplete(() =>
                    {
                        obj.isOn = true;
                    });
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void MoveTruckUp()
    {
        if (truckPoint.AdjacentForward != null)
        {
            //Coroutine internalEffectCoroutine = StartCoroutine(DoCollectingEffect());

            canProcessInput = false;

            smokeEffect.Play();

            // Calculate the direction from the current object position to the target in world space.
            Vector3 targetDir = (truckPoint.AdjacentForward.transform.position - transform.position).normalized;

            targetDirection = truckPoint.AdjacentForward.transform.position - transform.position;

            // Convert the target direction to local space (relative to the object's forward direction).
            Vector3 localTargetDir = transform.InverseTransformDirection(targetDir);

            // Calculate the angle to rotate around the Y axis (upwards).
            float angleToRotate = Mathf.Atan2(localTargetDir.x, localTargetDir.z) * Mathf.Rad2Deg;

            // Rotate the object around the Y axis to face the target direction.
            truckVisual.rotation = Quaternion.Euler(0f, angleToRotate, 0f);
            

            transform.DOMove(truckPoint.AdjacentForward.position, moveSpeed).OnComplete(() =>
            {
                canProcessInput = true;
                smokeEffect.Stop();
                //StopCoroutine(internalEffectCoroutine);
            });
            
            truckPoint = truckPoint.AdjacentForward.transform.GetComponent<TruckMovePoints>();
        }
    }

    public void MoveTruckDown()
    {

        if (truckPoint.AdjacentBackward != null)
        {
            //Coroutine internalEffectCoroutine = StartCoroutine(DoCollectingEffect());

            canProcessInput = false;

            smokeEffect.Play();

            // Calculate the direction from the current object position to the target in world space.
            Vector3 targetDir = (truckPoint.AdjacentBackward.transform.position - transform.position).normalized;

            targetDirection = truckPoint.AdjacentBackward.transform.position - transform.position;

            // Convert the target direction to local space (relative to the object's forward direction).
            Vector3 localTargetDir = transform.InverseTransformDirection(targetDir);

            // Calculate the angle to rotate around the Y axis (upwards).
            float angleToRotate = Mathf.Atan2(localTargetDir.x, localTargetDir.z) * Mathf.Rad2Deg;

            // Rotate the object around the Y axis to face the target direction.
            truckVisual.rotation = Quaternion.Euler(0f, angleToRotate, 0f);

            transform.DOMove(truckPoint.AdjacentBackward.position, moveSpeed).OnComplete(() =>
            {
                canProcessInput = true;
                smokeEffect.Stop();
                //StopCoroutine(internalEffectCoroutine);
            });
            
            truckPoint = truckPoint.AdjacentBackward.transform.GetComponent<TruckMovePoints>();
        }
    }

    public void MoveTruckLeft()
    {
        if (truckPoint.AdjacentLeft != null)
        {
            //Coroutine internalEffectCoroutine = StartCoroutine(DoCollectingEffect());

            canProcessInput = false;

            smokeEffect.Play();

            // Calculate the direction from the current object position to the target in world space.
            Vector3 targetDir = (truckPoint.AdjacentLeft.transform.position - transform.position).normalized;

            targetDirection = truckPoint.AdjacentLeft.transform.position - transform.position;

            // Convert the target direction to local space (relative to the object's forward direction).
            Vector3 localTargetDir = transform.InverseTransformDirection(targetDir);

            // Calculate the angle to rotate around the Y axis (upwards).
            float angleToRotate = Mathf.Atan2(localTargetDir.x, localTargetDir.z) * Mathf.Rad2Deg;

            // Rotate the object around the Y axis to face the target direction.
            truckVisual.rotation = Quaternion.Euler(0f, angleToRotate, 0f);

            transform.DOMove(truckPoint.AdjacentLeft.position , moveSpeed).OnComplete(() =>
            {
                canProcessInput = true;
                smokeEffect.Stop();
                //StopCoroutine(internalEffectCoroutine);
            });
            
            truckPoint = truckPoint.AdjacentLeft.transform.GetComponent<TruckMovePoints>();
        }
    }

    public void MoveTruckRight()
    {
        if (truckPoint.AdjacentRight != null)
        {
            //Coroutine internalEffectCoroutine = StartCoroutine(DoCollectingEffect());

            canProcessInput = false;
            smokeEffect.Play();

            // Calculate the direction from the current object position to the target in world space.
            Vector3 targetDir = (truckPoint.AdjacentRight.transform.position - transform.position).normalized;

            targetDirection = truckPoint.AdjacentRight.transform.position - transform.position;

            // Convert the target direction to local space (relative to the object's forward direction).
            Vector3 localTargetDir = transform.InverseTransformDirection(targetDir);

            // Calculate the angle to rotate around the Y axis (upwards).
            float angleToRotate = Mathf.Atan2(localTargetDir.x, localTargetDir.z) * Mathf.Rad2Deg;

            // Rotate the object around the Y axis to face the target direction.
            truckVisual.rotation = Quaternion.Euler(0f, angleToRotate, 0f);

            transform.DOMove(truckPoint.AdjacentRight.position, moveSpeed).OnComplete(() =>
            {
                canProcessInput = true;
                smokeEffect.Stop();
                //StopCoroutine(internalEffectCoroutine);

            });
            
            truckPoint = truckPoint.AdjacentRight.transform.GetComponent<TruckMovePoints>();
        }
    }
}
