using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject[] _powerUps;
    
    
    private bool _stopSpawn = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while(_stopSpawn == false)
        {
            var randAxis = Random.Range(-9.1f, 9.1f);
            var position = new Vector3(randAxis, 6.46f, 0);
            var newEnemy = Instantiate(_enemy, position, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3f);
        while(_stopSpawn == false)
        {
            //Random Position on the start of the game
            var randAxis = Random.Range(-9.1f, 9.1f);
            var position = new Vector3(randAxis, 6.8f, 0);
            var randPowerUp = Random.Range(0,3);
            Instantiate(_powerUps[randPowerUp], position, Quaternion.identity);
            var randWait = Random.Range(3f,8f);
            yield return new WaitForSeconds(randWait);
        }
    }

    public void playerIsDeath()
    {
        _stopSpawn = true;
    }
}
