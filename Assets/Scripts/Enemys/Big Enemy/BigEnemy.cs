using UnityEngine;

public class BigEnemy : Enemy
{
    void Start()
    {
        hp = 6f;
        speed = 2.5f;
        range = 15f;
        routineTime = 10f;

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
