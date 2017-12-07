using System;
using System.Collections;
using System.Collections.Generic;

using Manager;

using UnityEngine;

using Model;
using Model.character;


public abstract class Card {

    public string Name { get; set; }

    public string SimgleDesc { get; set; }

    public Character character;

    private Character target;

    protected int cooldownTime;

    protected int firstCooldown;

    public UCard uCard;

    public int FirstCooldown {
        get { return firstCooldown; }
        set { firstCooldown = value; }
    }

    public int CooldownTime {
        get { return cooldownTime; }
        set { cooldownTime = value; }
    }
    
    public virtual Character ChooseTarget(BattleManager manager, Character user) {
        if(user as Hero) {
            target=manager.Monster;
        }
        if(user as Monster) {
            target= manager.Hero;
        }
        return target;
    }

    public virtual void PlayEffect(BattleManager manager, Character user) {
        
    }

    public virtual bool CouldCharacterUse(BattleManager manager,Character user) {
        return uCard.CurrentCooldown<=0;
    }

}