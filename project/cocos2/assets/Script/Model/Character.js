cc.Class({
  extends: cc.Component,

  properties: {
    label: {
      default: null,
      type: cc.Label
    },
    // defaults, set visually when attaching this script to the Canvas
    text: 'Hello, World!',
    maxHealth: 30,
    currentHealth: 20,

  },

  // use this for initialization
  onLoad: function () {
    this.label.string = this.text;
  },

  // called every frame
  update: function (dt) {

  },
});
