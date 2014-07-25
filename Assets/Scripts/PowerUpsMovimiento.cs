using UnityEngine;
using System.Collections;

public class PowerUpsMovimiento : MonoBehaviour {
    public bool ejeYArriba;
    public bool ejeYAbajo;
    public bool ejeXDerecha;
    public bool ejeXIzquierda;
    public int velocidad;
    public float velocidadGlobal;

    public GameObject padre;

	void Start () {
        if (ejeYArriba)
            rigidbody.velocity = new Vector3(0, velocidad, 0);

        if (ejeYAbajo)
            rigidbody.velocity = new Vector3(0, -velocidad, 0);

        if (ejeXDerecha)
            rigidbody.velocity = new Vector3(velocidad, 0, 0);

        if (ejeXIzquierda)
            rigidbody.velocity = new Vector3(-velocidad, 0, 0);
    }

	void Update () {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Derecha")
            rigidbody.velocity = new Vector3(-velocidad, 0, 0);

        if (other.gameObject.tag == "Izquierda")
            rigidbody.velocity = new Vector3(velocidad, 0, 0);

        if (other.gameObject.tag == "Arriba")
            rigidbody.velocity = new Vector3(0, -velocidad, 0);

        if (other.gameObject.tag == "Abajo")
            rigidbody.velocity = new Vector3(0, velocidad, 0);

        if (other.gameObject.tag == "Killer" && this.gameObject.tag == "Next")
            Generador.OK = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Killer" || other.gameObject.tag == "Player")
        {
            Destroy(padre.gameObject);
        }
            
    }
}
