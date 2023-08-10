using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Right,
    Left,
    Forward,
    Backward
}

public class TruckMovePoints : MonoBehaviour
{
    public Transform AdjacentRight;
    public Transform AdjacentLeft;
    public Transform AdjacentForward;
    public Transform AdjacentBackward;
}
