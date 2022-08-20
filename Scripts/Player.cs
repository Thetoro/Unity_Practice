using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShot;
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _canFire = 0f;
    [SerializeField]
    private int _lives = 3;

    private SpawnManager _spawn;
    private bool _isTripleShotActive = false;
    private bool _isSpeedUpActive = false;
    private bool _isShieldActive = false;

    private GameObject _shield;

    private GameManager _gameManager;

    private UIManager _uiManager;
    [SerializeField]
    private int _score;

    public GameObject _rightEngine;
    public GameObject _leftEngien;

    [SerializeField]
    private AudioSource _laserAudio;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _shield = GameObject.Find("Shield");
        _shield.SetActive(false);
        transform.position = new Vector3(0,0,0);
        _spawn = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_spawn == null)
        {
            Debug.LogError("SpanwManager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(_isSpeedUpActive == true)
        {
            _speed = 8.5f;
        }
        else{
            _speed = 5f;
        }
        //Moving the object
        transform.Translate(new Vector3(horizontalInput,verticalInput,0)*_speed*Time.deltaTime);

        //Checking boundarys Y axis
        var clampY =  Mathf.Clamp(transform.position.y, -4.88f,0);
        transform.position = new Vector3(transform.position.x, clampY,0);
        //Checking boundarys X axis
        if(transform.position.x >= 11.30f)
        {
            transform.position = new Vector3(-11.30f,transform.position.y,0);
        } 
        else if(transform.position.x <= -11.30f)
        {
            transform.position = new Vector3(11.30f, transform.position.y, 0);
        }
    }

    void Shoot()
    {
        if(_isTripleShotActive == false)
        {
            _canFire = Time.time + _fireRate;
            var offset = new Vector3(0, 1.05f, 0);
            Instantiate(_laserPrefab, transform.position + offset, Quaternion.identity);
        }
        else
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_tripleShot, transform.position, Quaternion.identity);
        }
        
        _laserAudio.Play();
    }

    public void Damage()
    {

        if(_isShieldActive == true)
        {
            _isShieldActive = false;
            _shield.SetActive(false);
            return;
        }

        _lives--;

        _uiManager.UpdateLives(_lives);

        if(_lives == 2)
            _rightEngine.SetActive(true);
        if(_lives == 1)
            _leftEngien.SetActive(true);

        if(_lives < 1)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _gameManager.IsGameOver();
        _spawn.playerIsDeath();
        Destroy(this.gameObject);
        _uiManager.GameOver();
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerRoutine());
    }

    public void SpeedUPActive()
    {
        _isSpeedUpActive = true;
        StartCoroutine(SpeedUpRoutine());
    }

    public void ShieldActive()
    {
        _isShieldActive = true;
        _shield.SetActive(true);
    }

    public void SetScore(int points)
    {
        _score += points;
        _uiManager.printScore(_score);
    }

    IEnumerator SpeedUpRoutine()
    {
        while(_isSpeedUpActive == true)
        {
            yield return new WaitForSeconds(5f);
            _isSpeedUpActive = false;
        }
    }
    IEnumerator TripleShotPowerRoutine()
    {
        while(_isTripleShotActive == true)
        {
            yield return new WaitForSeconds(5f);
            _isTripleShotActive = false;
        }
    }
}
