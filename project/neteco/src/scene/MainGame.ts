class MainGame extends egret.Stage{

	public constructor() {
		super()
		this.addEventListener(egret.Event.ADDED_TO_STAGE, this.onAddToStage, this);
	}

	private heroStateUI:HeroStateUI

    private handsCardUI:HandsCard

	private onAddToStage(event:egret.Event) {
        this.heroStateUI=new HeroStateUI
        this.addChild(this.heroStateUI)
        this.handsCardUI=new HandsCard
        this.addChild(this.handsCardUI)
        console.log("MainGame init")
	}
}