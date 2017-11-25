
class Main extends egret.DisplayObjectContainer {

    private mainMenueUI:MainMenuUI;

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
		var arr=[this.beginGameField,this.continueGameField,this.exitGameField]
		for (let field of arr){
			field.anchorOffsetX=20
			field.anchorOffsetY=300
			field.width = 120;
			field.height = 20;
			field.textAlign = "center";
			this.addChild(field)
		}
		var x=0
		for (let field of arr){
			field.x=x
			x+=120
			field.y=0
		}
	}
    constructor() {
        super();    
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }
    
    private onAddToStage(event:egret.Event) {
        this.mainMenueUI=new MainMenuUI()
        this.addChild(this.mainMenueUI)
        // this.addMenues()
    }
}