using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {
    public float velocidad;
    public GameObject hijo;

	void Start () {
        this.gameObject.rigidbody.velocity = new Vector3(0, 0, velocidad);
	}
	

	void Update () {
        
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
}
