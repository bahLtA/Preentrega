using UnityEngine;

public class NormalEnemy : Enemy
{
    void Start()
    {
        hp = 3f;
        speed = 1f;
        range = 10f;
        routineTime = 4f;

        rb = GetComponent<Rigidbody>();
        timer = 0;

        //Busca el objeto con el tag "Player" para que este luego sea el target
        playerObj = GameObject.FindGameObjectWithTag("Player");
        target = playerObj.transform;

        //Busca el hijo del objeto "Enemy" que es el muñeco con el animator
        enemyChild = gameObject.transform.GetChild(0).gameObject;
        anim = enemyChild.GetComponent<Animator>();
    }

    void Update()
    {
        EnemyBehavior();
    }
}
