using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _zombiePrefab;
    [SerializeField]
    private Transform _spawningPlane;
    [SerializeField]
    private int _maxZombies;
    [SerializeField]
    private int _initialNumOfZombies;
    
    private Queue<GameObject> _unusedZombies = new Queue<GameObject>();
    private Queue<GameObject> _aliveZombies = new Queue<GameObject>();
    private Queue<GameObject> _deadZombies = new Queue<GameObject>();

    private void Start()
    {
        CreateInitialZombies();
        StartCoroutine(SpawnZombie());
    }

    private void CreateInitialZombies()
    {
        for (int i = 0; i < _maxZombies; ++i)
        {
            CreateNewZombie();
        }
    }

    private void CreateNewZombie()
    {
        //var zombie = Instantiate(_zombiePrefab[0], GetRandomPosition(), Quaternion.Euler(Vector3.zero));
        var zombie = Instantiate(_zombiePrefab[0], GetRandomPosition(), Quaternion.Euler(Vector3.zero));
        zombie.SetActive(false);
        _unusedZombies.Enqueue(zombie);
    }

    private Vector3 GetRandomPosition()
    {
        float x = _spawningPlane.position.x;
        float y = _spawningPlane.position.y;
        float z = _spawningPlane.position.z;

        float randomX = Random.Range(x - _spawningPlane.localScale.x / 2 * 10, x + _spawningPlane.localScale.x / 2 * 10);
        //float randomY = Random.Range(y - _spawningPlane.localScale.y / 2 * 10, y + _spawningPlane.localScale.y / 2 * 10);
        float randomZ = Random.Range(z - _spawningPlane.localScale.z / 2 * 10, z + _spawningPlane.localScale.z / 2 * 10);
        return new Vector3(randomX, y, randomZ);
    }

    public IEnumerator SpawnZombie()
    {
        while (_unusedZombies.Count > 0)
        {
            Debug.Log("Spawned zombie");
            var zombie = _unusedZombies.Dequeue();
            zombie.SetActive(true);
            _aliveZombies.Enqueue(zombie);
            yield return new WaitForSeconds(1f);
            yield return zombie;
        }
        yield break;
    }
}
