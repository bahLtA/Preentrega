using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator _animator;
    float vel=0;
    int count;
    float temp;
    bool isPunching;
    void Start()
    {
        
    }

    void Update()
    {
        WalkAnimations();
        PunchAnimations();
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
        if(Input.GetMouseButtonDown(0) && !isPunching)
        {

        }
    }

    void Cooldown()
    {

    }
    void Tempo()
    {
        temp += Time.deltaTime;
        if (temp >= 1)
        {
            temp = 0;
            count = 0;
        }
    }
}
