using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int _powerUpID;
    [SerializeField]
    private AudioClip _powUpAudio;

    // Update is called once per frame
    void Update()
    {
        //Going down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //Spawn at top after getting out of the screen
        if(transform.position.y <= -7f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var player = other.transform.GetComponent<Player>();
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_powUpAudio, transform.position);
            if(player != null)
            {
                switch(_powerUpID)
                {
                    case 0: player.TripleShotActive();
                            break;
                    case 1: player.SpeedUPActive();
                            break;
                    case 2: player.ShieldActive();
                            break;
                }
            }
                
            Destroy(this.gameObject);
        }
    }
}
