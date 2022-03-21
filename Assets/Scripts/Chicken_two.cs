using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myinterfaces;

public class Chicken_two : MonoBehaviour,Imovement
{
    public float dir = 3;
    private void Start()
    {
        StartCoroutine(chagedir());
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        transform.Translate(dir *Time.deltaTime, -10 * Time.deltaTime, 0);
        if(transform.position.y < -50)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator chagedir()
    {
        yield return new WaitForSeconds(4);
        dir *= -1;
    }

}
