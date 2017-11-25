
class Main extends egret.DisplayObjectContainer {

    private mainMenueUI:MainMenuUI;

    constructor() {
        super();    
        this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
    }
    
    private onAddToStage(event:egret.Event) {
        this.width=this.stage.width
        this.height=this.stage.height

        this.mainMenueUI=new MainMenuUI()
        this.addChild(this.mainMenueUI)
    }
}