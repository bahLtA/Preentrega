using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    public int amountEnemys,amountSpawns;
    public GameObject enemy;
    public GameObject spawn;
    Vector3 randPos;
    public Transform spawnPosition;

    GameObject remove;

    public List<GameObject> spawnList = new List<GameObject>();
    void Start()
    {
        for(int i = 0; i < amountSpawns; i++)
        {
            PositionRandomizer();
            spawnList.Add(new GameObject("Spawn " + i));
            spawnPosition.position = randPos;
            spawnList[i].transform.position = randPos;
            //Instantiate(spawn, spawnList[i].transform.position,transform.rotation);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("H Pressed, Spawning enemys");
            SpawnEnemys();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            amountSpawns--;
            Debug.Log("Spawn removed");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            amountSpawns++;
            Debug.Log("Spawn added");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            amountEnemys--;
            Debug.Log("Enemy removed");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            amountEnemys++;
            Debug.Log("Enemy added");
        }

        CheckSpawns();
    }

    void SpawnEnemys()
    {
        for (int i = 0; i < amountEnemys; i++)
        {
            spawnPosition.position = spawnList[i].transform.position;
            Instantiate(enemy, spawnPosition.position, transform.rotation);
        }
    }

    void CheckSpawns()
    {
        while(spawnList.Count != amountSpawns)
        {
            if(spawnList.Count < amountSpawns)
            {
                spawnList.Add(new GameObject("Spawn " + spawnList.Count));
                PositionRandomizer();
                spawnList[spawnList.Count-1].transform.position = randPos; 
            }
            else
            {
                remove = GameObject.Find("Spawn " + (spawnList.Count-1));
                spawnList.Remove(remove);
                Destroy(remove);
            }
        }
    }

    

    void PositionRandomizer()
    {
        randPos.x = Random.Range(-14, 14);
        randPos.z = Random.Range(-14, 14);
        randPos.y = 1.7f;
    }
}
