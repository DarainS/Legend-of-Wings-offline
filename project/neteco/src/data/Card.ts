
class Card extends egret.DisplayObjectContainer {

    constructor(){
        super()
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }

    private shape=new egret.Shape()

    public name:string='name'
    public bordColor:number=0xFFFFFF
    public simpleDesc:string='simple description'

    /**
     * 回合开始，回合结束
     *
     * 使用卡牌前后
     * 造成伤害前后
     * 受到伤害前后
     *
     * 摸牌阶段 前后
     * 出牌阶段 前后
     *
     * 各种标记
     */

    public beforeDamage:Array=[]
    public afterDamage:Array=[]

    public damage:Damage[]=[]

    private drawBord(){
        this.shape.graphics.beginFill(this.bordColor,1)
        var g=this.shape.graphics
        var width=200
        var height=240
        g.lineStyle(5)
        g.lineTo(0,0)
        g.lineTo(width,0)
        g.lineTo(width,height)
        g.lineTo(0,height)
        g.lineTo(0,0)
        g.endFill()
        this.addChildAt(this.shape,0)
    }

    private drawName(){
        var text=new egret.TextField()
        text.text=this.name
        if (this.name==null){
            return
        }
        text.width=250
        text.height=60
        text.x=(this.width-100)/2
        text.y=30
        text.size=25
        text.textColor=0x000000
        this.addChild(text)
    }

    private drawDesc(){
        var text=new egret.TextField()
        text.text=this.simpleDesc
        this.addChildAt(text,1)
    }

    public draw(){
        this.drawBord()
        this.drawName()
        this.drawDesc()
    }

    public openDrag(){
        this.touchEnabled = true;
        this.addEventListener(egret.TouchEvent.TOUCH_BEGIN, this.mouseDown, this);
        this.addEventListener(egret.TouchEvent.TOUCH_END, this.mouseUp, this);
    }

    _touchStatus=false

    private mouseDown(evt:egret.TouchEvent)
    {
        this._touchStatus = true;
        this.x = evt.stageX - this.x;
        this.y = evt.stageY - this.y;
        this.stage.addEventListener(egret.TouchEvent.TOUCH_MOVE, this.mouseMove, this);
    }

    private mouseMove(evt:egret.TouchEvent)
    {
        if( this._touchStatus )
        {
            console.log("moving now ! Mouse: [X:"+evt.stageX+",Y:"+evt.stageY+"]");
            this.x = evt.stageX - this.x;
            this.y = evt.stageY - this.y;
        }
    }

    private mouseUp(evt:egret.TouchEvent)
    {
        this._touchStatus = false;
        this.stage.removeEventListener(egret.TouchEvent.TOUCH_MOVE, this.mouseMove, this);
    }


    private onAddToStage(event:egret.Event) {
        this.width=200
        this.height=240
        this.draw()
        this.openDrag()
    }
    
}