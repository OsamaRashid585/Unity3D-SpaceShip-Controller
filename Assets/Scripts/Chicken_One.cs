using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myinterfaces;

public class Chicken_One : MonoBehaviour,Imovement
{
    private float _moveSpeed = 10;
    bool IsChange = true;

    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        if(IsChange)
        {
            transform.Translate(-_moveSpeed * Time.deltaTime, 0, 0);
        }
        if(IsChange == false)
        {
            transform.Translate(_moveSpeed * Time.deltaTime, 0, 0);
        }
    }
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightBorder"))
        {
            IsChange = true;
        }
        if (other.gameObject.CompareTag("LeftBorder"))
        {
            IsChange = false;
        }
    }
}
