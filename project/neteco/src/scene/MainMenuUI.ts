class MainMenuUI  extends egret.Stage {

	private beginGameField:egret.TextField;
	private continueGameField:egret.TextField;
	private exitGameField:egret.TextField;

	private mainGame:MainGame;

	private addMenues(){
		this.beginGameField=new egret.TextField()
		this.beginGameField.text="Begin Game"
		this.continueGameField=new egret.TextField()
		this.continueGameField.text="Continue Game"
		this.exitGameField=new egret.TextField()
		this.exitGameField.text="Exit"
		var arr=[this.beginGameField,this.continueGameField,this.exitGameField]

		this.beginGameField.anchorOffsetX=0
		this.beginGameField.anchorOffsetY=0
		this.beginGameField.width = 400;
		this.beginGameField.height = 80;
		this.beginGameField.size=60
		this.beginGameField.textAlign = "center";
		this.beginGameField.x=400;
		this.beginGameField.y=400;
		this.beginGameField.textColor=0x000000
		
		this.addChild(this.beginGameField)

        this.beginGameField.$setTouchEnabled(true)
		this.beginGameField.addEventListener(egret.TouchEvent.TOUCH_TAP,()=>{
		    this.parent.addChild(this.mainGame)
			this.parent.removeChild(this)
		},this)
	}

	public constructor() {
		super()
		this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
	}

	private onAddToStage(event:egret.Event) {
		this.addMenues()
        this.mainGame=new MainGame;
	}

}