using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulit : MonoBehaviour
{
    private float _moveSpeed = 70;
    private GameObject _player;
    private void Awake()
    {
        _player = GameObject.FindObjectOfType<Player>().gameObject;
    }
    private void Update()
    {
        transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);

        if (transform.position.y >= 50)
        {
            gameObject.SetActive(false);
            transform.position = _player.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
