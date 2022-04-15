using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public int health;
    public GameObject Ability { get; }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reduceHealth(int points) {

        health -= points;
    }

    public abstract void Attack();

}
