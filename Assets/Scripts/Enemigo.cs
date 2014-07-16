using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {
    public float velocidad;
    public GameObject hijo;

    private bool atrayendo;

	void Start () {
        atrayendo = false;
	}

	void Update () {
        
        if(Time.timeScale >= 1 && !atrayendo)
            transform.Translate(0, 0, velocidad * Cerebro.TURBO);


        if (Cerebro.ESTADO == "Atravesando" && this.gameObject.tag == "Enemigo")
            StartCoroutine(WaitVida(6));
    }

    void Atrayendo() 
    {
        atrayendo = true;   //Funciona sólo para detener su movimiento para ser absorvidos correctamente.
    }

    IEnumerator WaitVida(int time)
    {
        this.gameObject.collider.enabled = false;
        yield return new WaitForSeconds(time);
        if (Cerebro.ESTADO == "Atravesando")        //TENER CUIDADO CON EL YIELD PORQUE DESPUÉS DE ESTE PUNTO SE SIGUE APLICANDO LOS EFECTOS.
        {
            this.gameObject.collider.enabled = true;
            Cerebro.ESTADO = "Jugando";
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        //DESTRUYE EL OBJETO A SALIR DE LA ZONA VISIBLE.
        if (other.gameObject.tag == "Killer")
            Destroy(this.gameObject);

        //ELIMINA EL COLLIDER EXTERNO Y EL MESH DE LA IMAGEN PARA "DESAPARECER" EL OBJETO.
        if (other.gameObject.tag == "Player" && Cerebro.ESTADO != "Super Cerda")
        {
            this.gameObject.collider.enabled = false;
            hijo.gameObject.renderer.enabled = false;
        }

        //SI CHOCA CON EL CABALLERO Y ESTÁ EN MODO SUPER CERDA LO LANZA VOLANDO A LA CAMARA.
        if (other.gameObject.tag == "Player" && Cerebro.ESTADO == "Super Cerda" && this.gameObject.tag == "Enemigo")
        {
            atrayendo = true;
            rigidbody.velocity = new Vector3(0,25,0);
        }
    }

    
    /*ACCIONES PARA SACAR LA SIGUIENTE PLANTILLA.*
    *********************************************/
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Killer" && this.gameObject.tag == "Next") 
            Generador.OK = true;
    }
}
