using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;

    private static int _idIndex = 0;

    private Camera _mainCamera;
    private GameObject _player;

    private void Start()
    {
        //TODO: At some point, fix spawning so objects do not spawn within a radius of the player
        _player = GameObject.FindWithTag("Player");
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        GameEvents.events.onLevelStart += SetSpawnIndex;
    }

    private void OnDisable()
    {
        GameEvents.events.onLevelStart -= SetSpawnIndex;
    }

    // Spawns all Enemy objects listed in GameManager and assigns unique Id also listed in GameManager as enemyObjectId to each
    public void SpawnObjectsRandomly()
    {
        var spawnAmounts = GetRandomSpawnVariables();
        var spawnIndex = 0;
        
        foreach (var item in objectsToSpawn)
        {
            var spawnedObjects = new List<GameObject>();
            // set spawnArea to camera view, create random rotation direction on z, instantiate
            for (int i = 0; i < spawnAmounts[spawnIndex]; i++)
            {
                var spawnArea = _mainCamera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 10));
                var facingDirection = new Vector3(0, 0, Random.Range(0, 360));
                
                spawnedObjects.Add(Instantiate(item, spawnArea, Quaternion.Euler(facingDirection)));
               
                spawnedObjects[i].GetComponent<EnemyBase>().Id = _idIndex;
                _idIndex++;
            }
            spawnIndex++;
        }
    }

    // Get random amount for each item on objectsToSpawn(Enemy) list to spawn
    private List<int> GetRandomSpawnVariables()
    {
        var spawnAmount = new List<int>();
        int number;
        foreach (var item in objectsToSpawn)
        {
            spawnAmount.Add(number = Random.Range(3, 10));
        }
        return spawnAmount;
    }

    private void SetSpawnIndex()
    {
        _idIndex = 0;
    }
}
