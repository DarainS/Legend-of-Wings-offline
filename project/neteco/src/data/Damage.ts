enum DamageType {
    PHYSICAL,
    FIRE,
    WATER,
    ICE,
    REAL,
    AIR,
    ELECTRON,


}
class Damage{

    public num:number;

    public type;

    constructor(num:number,type:DamageType=DamageType.PHYSICAL){
        this.num=num
        this.type=type
    }

}