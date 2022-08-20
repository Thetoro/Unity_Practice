using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float _speed = 4f;
    private Player _player;
    [SerializeField]
    private Animator _enemyAnim;
    private AudioSource _explosionSound;
    private void Start() 
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _explosionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Going down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //Spawn at top after getting out of the screen
        if(transform.position.y <= -7f)
        {
            var randAxis = Random.Range(-9.1f,9.1f);
            transform.position = new Vector3(randAxis, 6.8f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            var player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                player.Damage();
            }

            _enemyAnim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            if(_explosionSound != null)
                _explosionSound.Play();
            Destroy(this.gameObject, 2.4f);
            
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if(_player != null)
            {
                _player.SetScore(10);
            }

            _enemyAnim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            if (_explosionSound != null)
                _explosionSound.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.4f);
        }
    }
}
