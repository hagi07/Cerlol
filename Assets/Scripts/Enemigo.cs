using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {
    public float velocidad;
    public GameObject hijo;

	void Start () {
        
	}

	void Update () {
        if(Time.timeScale >= 1)
            transform.Translate(0, 0, velocidad * Cerebro.TURBO);
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Killer")
            Destroy(this.gameObject);

        if (other.gameObject.tag == "Player")
        {
            this.gameObject.collider.enabled = false;
            hijo.gameObject.renderer.enabled = false;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Killer" ) 
            Generador.OK = true;
    }
}
