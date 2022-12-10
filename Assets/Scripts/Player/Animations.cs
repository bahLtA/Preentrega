using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator _animator;
    float vel=0;
    public int count;
    public float temp;
    public bool isPunching;

    public BoxCollider[] punchCollider;


    void Start()
    {
        DeactivePunchCollider();
    }

    void Update()
    {
        WalkAnimations();
        PunchAnimations();
        Cooldown();
    }

    void WalkAnimations()
    {
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && vel > 0)
        {
            vel -= Time.deltaTime * 5f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vel += Time.deltaTime * 5f;
        }
        if (!Input.GetKey(KeyCode.LeftShift) && vel > 0.5f)
        {
            vel -= Time.deltaTime * 5f;
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && vel < 0.5f)
        {
            vel += Time.deltaTime * 5f;
        }
        if (vel > 1f)
        {
            vel = 1f;
        }
        _animator.SetFloat("Speed", vel);
    }

    void PunchAnimations()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetInteger("Count", count);
            count++;
            temp = 0;
        }
        else
        {
            Cooldown();
            _animator.SetInteger("Count", count);
        }
        if (count == 4)
        {
            count = 0;
        }
    }

    void Cooldown()
    {
        temp += Time.deltaTime;
        if (temp >= 1f)
        {
            temp = 0;
            count = 0;
        }
    }

    void DeactivePunchCollider()
    {
        for (int i = 0; i < punchCollider.Length; i++)
        {
            if (punchCollider[i] != null)
            {
                punchCollider[i].enabled = false;
            }

        }
    }

    void ActivePunchCollider()
    {
        for (int i = 0; i < punchCollider.Length; i++)
        {
            if (punchCollider[i] != null)
            {
                punchCollider[i].enabled = true;
            }
        }
    }
}
