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
    public int MaxZombies
    {
        get => _maxZombies;
        private set { }
    }

    private Queue<GameObject> _unusedZombies = new Queue<GameObject>();
    private List<GameObject> _aliveZombies = new List<GameObject>();
    private Queue<GameObject> _deadZombies = new Queue<GameObject>();
    public int DeadZombiesCount
    {
        get => _deadZombies.Count;
        private set { }
    }

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
        var zombie = Instantiate(_zombiePrefab[0], GetRandomPosition(), GetRandomRotation());
        zombie.SetActive(false);
        //zombie.GetComponent<HP>().OnDeathWithGameObject.AddListener(OnZombieDies);
        _unusedZombies.Enqueue(zombie);
    }

    private Vector3 GetRandomPosition()
    {
        float x = _spawningPlane.position.x;
        float y = _spawningPlane.position.y;
        float z = _spawningPlane.position.z;

        float randomX = Random.Range(x - _spawningPlane.localScale.x / 2 * 10, x + _spawningPlane.localScale.x / 2 * 10);
        float randomZ = Random.Range(z - _spawningPlane.localScale.z / 2 * 10, z + _spawningPlane.localScale.z / 2 * 10);
        return new Vector3(randomX, y, randomZ);
    }

    private Quaternion GetRandomRotation()
    {
        float randomY = Random.Range(0, 360);
        return Quaternion.Euler(new Vector3(0, randomY, 0));
    }

    public IEnumerator SpawnZombie()
    {
        while (_unusedZombies.Count > 0)
        {
            Debug.Log("Spawned zombie");
            var zombie = _unusedZombies.Dequeue();
            zombie.SetActive(true);
            _aliveZombies.Add(zombie);
            yield return new WaitForSeconds(1f);
            yield return zombie;
        }
        yield break;
    }

    public void RemoveZombie(GameObject zombie)
    {
        Debug.Log($"{zombie.name} dies");
        _aliveZombies.Remove(zombie);
        zombie.SetActive(false);
        _deadZombies.Enqueue(zombie);
    }
}
