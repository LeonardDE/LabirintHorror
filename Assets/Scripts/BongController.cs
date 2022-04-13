using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class BongController : MonoBehaviour
{
    private Tupick[] arrayTupick;
    private Tupick TupickWithMaxDistance;

    public float _rollBackTime = 0;
    public int _countBongo = 1;

    // Start is called before the first frame update
    void Start()
    {
        //arrayTupick = GameObject.FindGameObjectsWithTag("Tupick");
        arrayTupick = GameObject.FindObjectsOfType<Tupick>();
        
    }

    void Update()
    {
        if (_countBongo >= 0)
        {
            _rollBackTime -= Time.deltaTime;
            if (_rollBackTime <= 0)
            {
                _countBongo = 1;
                _rollBackTime = 0;
            }
        }
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if ( _rollBackTime == 0f && collisionInfo.gameObject.tag == "Tupick" && Input.GetKeyDown(KeyCode.F))
        {
            _rollBackTime = 150;
            _countBongo = 0;
            
            float distance = collisionInfo.gameObject.GetComponent<Tupick>().distanceToExit;
            Random rnd = new Random();
            int i = rnd.Next(0, arrayTupick.Length - 1);
            
            
            float newDistance = arrayTupick[i].distanceToExit; 
            
            while (newDistance < distance  || arrayTupick[i] == collisionInfo.gameObject.GetComponent<Tupick>())
            {
                i = rnd.Next(0, arrayTupick.Length - 1);
            }
            TupickWithMaxDistance = arrayTupick[i];

            transform.position = TupickWithMaxDistance.transform.position + new Vector3(0,2,0);
        }
    }
}
