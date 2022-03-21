using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myinterfaces;

public class Rock_One : MonoBehaviour,Imovement
{
    private void Start()
    {

    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        if (transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
   
}
