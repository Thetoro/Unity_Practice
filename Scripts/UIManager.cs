using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _liveImage;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _restarText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _restarText.gameObject.SetActive(false);
    }

    public void printScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives)
    {
        _liveImage.sprite = _liveSprites[currentLives];
    }

    public void GameOver()
    {
        StartCoroutine(FlickGameOverRoutin());
        _restarText.gameObject.SetActive(true);
    }

    IEnumerator FlickGameOverRoutin()
    {
        while(true)
        {
            _gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        } 
    }
}
