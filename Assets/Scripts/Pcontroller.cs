using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcontroller : MonoBehaviour
{
    private float Ver, Hor;
    public float SpeedMove = 1;
    public float SpeedCurrent;
    public float SpeedRun;

    public float staminaValue = 3;
    public float staminConstant = 3;
    public bool staminBelowZero = false;

    public bool PlayerLoud = false;

    private void Update()
    {
        Ver = Input.GetAxis("Vertical");
        Hor = Input.GetAxis("Horizontal");

        PlayerLoud = Input.GetKey(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        if (staminaValue <= 0)
            staminBelowZero = true;
        
        
        Move();
        
    }

    void Move()
    {
       
        if (staminBelowZero)
        {
            SpeedCurrent = SpeedMove;
            staminaValue += Time.deltaTime / staminConstant;
            if (staminaValue >= staminConstant)
            {
                staminaValue = staminConstant;
                staminBelowZero = false;
            }
        }
        else
        {
            Stamina();
        }
        

        transform.Translate(new Vector3(Hor, 0, Ver) * Time.deltaTime * SpeedCurrent);
    }

    private void Stamina()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(Hor) + Mathf.Abs(Ver) >= 1 && staminaValue > 0)
        {
            if (staminaValue <= 0)
            {
                
                staminaValue = 0;
                staminBelowZero = true;
            }
            else
            {
                staminaValue -= Time.deltaTime;    
            }

            SpeedCurrent = SpeedRun;
        }
        else
        {
            if (staminaValue >= staminConstant)
            {
                staminaValue = staminConstant;
            }
            else
            {
                staminaValue += Time.deltaTime / staminConstant;
            }

            SpeedCurrent = SpeedMove;
        }
    }

    
        
}
    

