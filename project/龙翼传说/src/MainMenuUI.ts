class MainMenuUI  extends egret.Stage {

	private beginGameField:egret.TextField;
	private continueGameField:egret.TextField;
	private exitGameField:egret.TextField;

	private addMenues(){
		this.beginGameField=new egret.TextField()
		this.beginGameField.text="Begin Game"
		this.continueGameField=new egret.TextField()
		this.continueGameField.text="Continue Game"
		this.exitGameField=new egret.TextField()
		this.exitGameField.text="Exit"
		// var arr=[this.beginGameField,this.continueGameField,this.exitGameField]
			this.beginGameField.anchorOffsetX=20
			this.beginGameField.anchorOffsetY=300
			this.beginGameField.width = 120;
			this.beginGameField.height = 20;
			this.beginGameField.textAlign = "center";
			this.addChild(this.beginGameField)
		
	}

	public constructor() {
		super()
		this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
	}

	private onAddToStage(event:egret.Event) {
		this.addMenues()
	}

}