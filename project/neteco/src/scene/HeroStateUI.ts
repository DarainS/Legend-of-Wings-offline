class HeroStateUI extends egret.DisplayObjectContainer{

    public constructor() {
        super()
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }

    private onAddToStage(event:egret.Event) {
        var shape=new egret.Shape()
        shape.graphics.beginFill(0xff0000 + Math.floor(Math.random() * 100) * (0xffffff / 100), 1);
        shape.graphics.drawRect(0,this.stage.height-400,this.stage.width,400)
        shape.graphics.endFill()
        this.addChild(shape)
        console.log("HeroStateUI add shape")
    }
}