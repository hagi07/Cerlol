using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {
    public bool vida1;
    public bool vida2;
    public bool vida3;
    public bool vida4;

	void Start () {

	}
	
	
	void Update () {
        if (vida4 && Cerebro.VIDA < 4)
            this.gameObject.renderer.enabled = false;
        
        if (vida3 && Cerebro.VIDA < 3)
            this.gameObject.renderer.enabled = false;

        if (vida2 && Cerebro.VIDA < 2)
            this.gameObject.renderer.enabled = false;

        if (vida1 && Cerebro.VIDA < 1)
            this.gameObject.renderer.enabled = false;
	}
}
