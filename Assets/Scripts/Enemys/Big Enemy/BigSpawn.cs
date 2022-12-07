using UnityEngine;

public class BigSpawn : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPosition;
    Vector3 randPos;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            PositionRandomizer();
            spawnPosition.position = randPos;
            Instantiate(enemy, spawnPosition.position, transform.rotation);
        }
    }
    void PositionRandomizer()
    {
        randPos.x = Random.Range(-14, 14);
        randPos.z = Random.Range(-14, 14);
        randPos.y = 1.7f;
    }
}
