using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tupick : MonoBehaviour
{
    public float distanceToExit;
    public GameObject _dour;

    private void Start()
    {
        distanceToExit = (transform.position - _dour.transform.position).magnitude;
    }
}
