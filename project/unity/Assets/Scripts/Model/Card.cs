using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;


public abstract class Card
{

    public string Name
    {
        get;
        set;
    }

    public string SimgleDesc
    {
        get;
        set;
    }


    public Character character;

    protected int cooldownTime;

    protected int firstCooldown;


    public int FirstCooldown
    {
        get { return firstCooldown; }
        set { firstCooldown = value; }
    }

    public int CooldownTime { 
        get { return cooldownTime; }
        set { cooldownTime = value; } }

    public virtual void PlayEffect(Character player,Character target)
    {
        
    }

    public virtual bool CouldCharacterUse(Character c)
    {
        return true;
    }

}