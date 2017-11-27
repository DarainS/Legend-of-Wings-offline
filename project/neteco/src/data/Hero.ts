class Deck {

    public cards: Array = []

}

class State{

    public name:string

    public source

    public type

    public num

}

class Hero extends egret.DisplayObjectContainer {

    public battle;

    public hp: number;

    public maxHP: number;

    /**
     * 能量属性 mana, energy, anger
     */

    public energyType;

    public mana: number;

    public actionSpeed: number;

    /**
     * 英雄属性：卡组
     */

    public deck: Array = [];


    /**
     * 战斗时卡牌在如下位置：牌堆，墓地，手牌，战场，装备区
     *
     */

    public packet: Array = []

    public grave: Array = []

    public handsCard: Array = []

    public battleYard: Array = []


    public energy(): number {
        return this[this.energyType]
    }

    constructor() {
        super();
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }

    private onAddToStage(event: egret.Event) {

    }

    private beforeDamage: Array = []

    private afterdamage: Array = []

    private onDamage(damage) {
        this.beforeDamage.sort((a: Card, b: Card) => {
            let o1 = a['beforeDamage']['order'];
            let o2 = b['beforeDamage']['order'];
            if (o1 === o2) {
                return 0
            }
            return o1 > o2 ? 1 : -1
        })
    }

}