using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _rotationSpeed = 10;
    private Vector3 _currPos;
    public GameObject explosion;
    private SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
        _currPos = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Laser")
        {
            Destroy(this.gameObject, 0.2f);
            Destroy(other.gameObject);
            _spawnManager.StartSpawning();
            Instantiate(explosion, _currPos, Quaternion.identity);
        }
    }
}
