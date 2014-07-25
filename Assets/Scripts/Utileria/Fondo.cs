using UnityEngine;
using System.Collections;

public class Fondo : MonoBehaviour {
    public float scrollSpeed;
    public float offset;

	void Start () {
	
	}
	
	void Update () {
        offset += (scrollSpeed * Cerebro.TURBO * Cerebro.AUMENTO * Time.deltaTime) / 100;
	    renderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}

