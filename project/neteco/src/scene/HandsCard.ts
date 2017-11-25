class HandsCard extends egret.Stage{

    public constructor() {
        super()
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }

    private onAddToStage(event:egret.Event) {
        var card=new Card()
        card.name="寒冰攻击"
        this.addChild(card)
    }


}