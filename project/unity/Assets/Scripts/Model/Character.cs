using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {
    public int currentHealth;
    public int maxHealth;

    public Slider slider;

    // Use this for initialization
    void Start() {
        slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update() {
    }
}