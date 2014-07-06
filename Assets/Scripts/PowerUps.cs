using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
    public Texture2D[] powerUp;
    public static int eleccion;

    void Start()
    {
        eleccion = 0;
    }
	
	void Update () {
        this.gameObject.renderer.material.SetTexture("_MainTex", powerUp[eleccion]); 
	}
}
