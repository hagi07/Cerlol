using UnityEngine;
using System.Collections;

public class ObstaculosGenericos : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        
	}

    void OnCollisionEnter(Collision other) 
    {
        if ((this.gameObject.tag == "Moneda" || this.gameObject.tag == "Cristal") && other.gameObject.tag == "Player")
            Destroy(this.gameObject);

        if (this.gameObject.tag == "Lanzas" && other.gameObject.tag == "Player")
        { }//Poner animación de lanzas rotas.
    }
}
