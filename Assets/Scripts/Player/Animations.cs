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

    float[] animDuration = new float[3];

    
    void Start()
    {
        animDuration[0] = 1;
        animDuration[1] = 1;
        animDuration[2] = 1.33f;
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
        if(Input.GetKeyDown(KeyCode.Mouse0) && !isPunching)
        {
            if (count == 0)
            {
                count++;
            }
            switch (count)
            {
                case 1:
                    _animator.SetInteger("Count",count);
                    isPunching = true;
                    count++;
                    Cooldown();
                    break;
                case 2:
                    _animator.SetInteger("Count",count);
                    isPunching = true;
                    Cooldown();
                    break;
                case 3:
                    _animator.SetInteger("Count",count);
                    isPunching = true;
                    count = 0;
                    Cooldown();
                    break;
            }
        }
    }

    void Cooldown()
    {
        temp += Time.deltaTime;
        if (temp > animDuration[count])
        {
            temp = 0;
            isPunching= false;
        }
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
