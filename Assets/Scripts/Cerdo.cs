using UnityEngine;
using System.Collections;

public class Cerdo : MonoBehaviour {
    public float velocidad;
    public float fuerzaDeSalto;
    public float arriba;
    public float abajo;
    public float izquierda;
    public float derecha;
    
    private bool saltoOK;

	void Start () {
        arriba = 6.04477f;
        abajo = -8.905528f;
        derecha = 8.588431f;
        izquierda = -8.472874f;
        this.gameObject.transform.position = new Vector3(0, 2.051136f, -8.905528f);
	}


    void Update()
    {
        //Establecen el movimiento del personaje.
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        transform.Translate(x, 0, y);

        //Establece los límites del juego.
        Limites();

        //Controla el salto del cerdo cuando está en el suelo.
        if (Input.GetKey(KeyCode.Space) && saltoOK)
            rigidbody.velocity = new Vector3(0, fuerzaDeSalto, 0);

        //Establece el cambio de velocidades.
        Velocidades();
    }


    void Limites() 
    {
        if (this.gameObject.transform.position.z <= abajo)
            transform.position = new Vector3(transform.position.x, transform.position.y, abajo + .0001f);

        if (this.gameObject.transform.position.z >= arriba)
            transform.position = new Vector3(transform.position.x, transform.position.y, arriba - .0001f);

        if (this.gameObject.transform.position.x >= derecha)
            transform.position = new Vector3(derecha - .0001f, transform.position.y, transform.position.z);

        if (this.gameObject.transform.position.x <= izquierda)
            transform.position = new Vector3(izquierda + .0001f, transform.position.y, transform.position.z);
    }

    void Velocidades() 
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Time.timeScale == 4)
                Time.timeScale = 5;

            if (Time.timeScale == 2)
                Time.timeScale = 4;

            if (Time.timeScale == 1)
                Time.timeScale = 2;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.timeScale == 2)
                Time.timeScale = 1;

            if (Time.timeScale == 4)
                Time.timeScale = 2;

            if (Time.timeScale == 5)
                Time.timeScale = 4;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo")
            Cerebro.VIDA--;
    }

    void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag == "Suelo")
            saltoOK = true;
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Suelo")
            saltoOK = false;
    }

}


