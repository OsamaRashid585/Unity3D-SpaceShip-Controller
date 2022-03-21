using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _moveSpeed = 600;
    private float _rotateSpeed = 0.1f;
    private float _inpX;
    private Rigidbody _rb;
    private Stack<GameObject> _bulitsPolling = new Stack<GameObject>();
    public List<GameObject> _bulitsList = new List<GameObject>();
    private GameObject built;
    private bool _canShoot = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        built = GameObject.FindObjectOfType<Bulit>().gameObject;
    }

    private void Start()
    {
        
        for(int i=0; i < 20; i++)
        {
            _bulitsList.Add(Instantiate(built,transform.position,Quaternion.identity));
        }
    }
    private void Update()
    {
        _inpX = Input.GetAxis("Horizontal");
        
    }

    private void FixedUpdate()
    {
        Movement();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && _canShoot)
        {
            transform.position = new Vector3(transform.position.x, -35, transform.position.z);
            var stackbulit = _bulitsPolling.Pop();
            stackbulit.transform.position = transform.position + new Vector3(0,7,0);
            stackbulit.SetActive(true);
            _canShoot = false;
            StartCoroutine(ShootDelay());
            StartCoroutine(BumpDelay());
        }

        if (_bulitsPolling.Count <= 0)
        {
            foreach (var b in _bulitsList)
            {
                _bulitsPolling.Push(b);
            }
        }
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(0.2f); 
        _canShoot = true;
    }
    IEnumerator BumpDelay()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = new Vector3(transform.position.x, -34, transform.position.z);
    }
    private void Movement()
    {
        //move the player
        _rb.AddForce(Vector3.right * _inpX * _moveSpeed * Time.deltaTime, ForceMode.Impulse);
        //tilt player
        if (_inpX < 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 20), _rotateSpeed);
        if (_inpX > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, -20), _rotateSpeed);
        if (_inpX == 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-90, 0, 0), _rotateSpeed);
        // bound on the screen
        if (transform.position.x > 100)
            transform.position = new Vector3(100, transform.position.y, transform.position.z);
        if (transform.position.x < -100)
            transform.position = new Vector3(-100, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("bulit"))
        {
            Destroy(gameObject);
        }
    }
}
