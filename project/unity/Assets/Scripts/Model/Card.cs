using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;


public abstract class Card
{
    protected string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string SimgleDesc
    {
        get { return simgleDesc; }
        set { simgleDesc = value; }
    }

    protected string simgleDesc;

    public Character character;

    public virtual void playEffect(Character target = null)
    {
        
    }

    public virtual bool isUseable()
    {
        return true;
    }
}