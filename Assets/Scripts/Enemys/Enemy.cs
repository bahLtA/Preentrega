using UnityEngine;

public class Enemy : MonoBehaviour
{
    //global
    public Animator anim;
    public float hp;
    public GameObject playerObj;
    public GameObject enemyChild;
    public float damageReceived;

    //Comportamiento del enemigo
    int routine;
    public float timer,degree;
    public float speed;
    Quaternion quat;
    public Rigidbody rb;
    public Transform target;
    public float range;
    public LayerMask player;
    bool detectPlayer;
    public float routineTime;

    //Animaciones cuando recibe un golpe
    
    public int damagePunch;
    
    public void EnemyBehavior()
    {
        detectPlayer = Physics.CheckSphere(transform.position, range, player);

        if (detectPlayer)
        {
            transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
            rb.velocity = transform.forward * speed + new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            timer += 1 * Time.deltaTime;
            if (timer >= routineTime)
            {
                routine = Random.Range(0, 2);
                timer = 0;
            }
            switch (routine)
            {
                case 0:
                    break;
                case 1:
                    degree = Random.Range(0, 360);
                    quat = Quaternion.Euler(0, degree, 0);
                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,quat,0.5f);
                    rb.velocity = transform.forward * speed + new Vector3(0, rb.velocity.y, 0);
                    break;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "punchImpact")
        {
            if(anim != null)
            {
                anim.Play("Taking Punch");
            }
            hp -= damagePunch;
        }

        if(hp <= 0)
        {
            Die();
        }
    }
}
