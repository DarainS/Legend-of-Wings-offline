using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Model
{

public class Character : MonoBehaviour
{


    protected LinkedList<Action> beforeDamage = new LinkedList<Action>();
    protected LinkedList<Card> afterDamage = new LinkedList<Card>();

    public LinkedList<Action> BeforeDamage
    {
        get
        {
            return beforeDamage;
        }

        set
        {
            beforeDamage = value;
        }
    }

        public LinkedList<Card> AfterDamage
    {
        get
        {
            return afterDamage;
        }

        set
        {
            afterDamage = value;
        }
    }

    public void onDamage()
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
}
