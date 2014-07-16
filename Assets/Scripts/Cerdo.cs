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
    private bool vidaMenosOk;

    public SpriteRenderer hijo;

    public float velocidadDeMonedas;

	void Start () {
        arriba = 6.04477f;
        abajo = -8.905528f;
        derecha = 8.588431f;
        izquierda = -8.472874f;
        this.gameObject.transform.position = new Vector3(0, 2.051136f, -8.905528f);
        vidaMenosOk = true;
	}


    void Update()
    {
        //Establecen el movimiento del personaje.
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad * Cerebro.TURBO;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * velocidad * Cerebro.TURBO;
        transform.Translate(x, 0, y);

        //Establece los límites del juego.
        Limites();

        //Controla el salto del cerdo cuando está en el suelo.
        if (Input.GetKey(KeyCode.Space) && saltoOK)
            rigidbody.velocity = new Vector3(0, fuerzaDeSalto, 0);

        //Establece el cambio de velocidades.
        Velocidades();

        if (Input.GetKey(KeyCode.Q) && Cerebro.ESTADO == "Jugando") 
        {
            if (PowerUps.eleccion == 1)
            {
                Cerebro.ESTADO = "Atravesando";
                hijo.color = new Color(58f, 182f, 255f, .2f);
            }

            if (PowerUps.eleccion == 2)
            {
                Cerebro.ESTADO = "Escudo";
                vidaMenosOk = false;
                hijo.color = new Color(58f, 182f, 255f, .2f); //MODIFICAR ESTA LINEA MÁS ADELANTE.
            }

            if (PowerUps.eleccion == 3)
                StartCoroutine(WaitPowerUp(30, "Aspirando"));

            if (PowerUps.eleccion == 4)
                StartCoroutine(WaitPowerUp(7, "Super Cerda"));


            PowerUps.eleccion = 0;
        }

        if(Cerebro.ESTADO == "Jugando")
            hijo.color = new Color(1f, 1f, 1f, 1f);

        if (Cerebro.ESTADO == "Aspirando") 
        {
            Collider[] hit = Physics.OverlapSphere(this.transform.position,7);
            for (int i = 0; i < hit.Length; i++) 
            {
                if (hit[i].gameObject.tag == "Moneda" || hit[i].gameObject.tag == "Cristal")
                {
                    Vector3 vector = this.gameObject.transform.position - hit[i].transform.position;
                    hit[i].transform.position += vector * velocidadDeMonedas * Time.deltaTime;
                    hit[i].BroadcastMessage("Atrayendo", SendMessageOptions.RequireReceiver);
                }
            }
        }
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
            if (Cerebro.TURBO == 4)
                Cerebro.TURBO = 5;

            if (Cerebro.TURBO == 3)
                Cerebro.TURBO = 4;

            if (Cerebro.TURBO == 2)
                Cerebro.TURBO = 3;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Cerebro.TURBO == 3)
                Cerebro.TURBO = 2;

            if (Cerebro.TURBO == 4)
                Cerebro.TURBO = 3;

            if (Cerebro.TURBO == 5)
                Cerebro.TURBO = 4;
        }
    }

    IEnumerator WaitVida(int time)
    {
        vidaMenosOk = false;
        yield return new WaitForSeconds(time);
        vidaMenosOk = true;
    }

    IEnumerator WaitPowerUp(int time, string estado)
    {
        Cerebro.ESTADO = estado;
        yield return new WaitForSeconds(time);
        if (Cerebro.ESTADO == estado) 
            Cerebro.ESTADO = "Jugando";
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo" && vidaMenosOk && Cerebro.ESTADO != "Super Cerda")
        {
            StartCoroutine(WaitVida(2));
            Cerebro.VIDA--;
            Cerebro.TURBO = 2;
        }

        if (other.gameObject.tag == "PowerUp")
            //PowerUps.eleccion = Random.Range(1, 4);
            PowerUps.eleccion = 4;

        if (other.gameObject.tag == "Moneda")
            Cerebro.MONEDAS++;

        if (other.gameObject.tag == "Cristal")
            Cerebro.CRISTAL++;

        if (other.gameObject.tag == "Enemigo" && !vidaMenosOk && Cerebro.ESTADO == "Escudo")
        {
            vidaMenosOk = true;
            Cerebro.ESTADO = "Jugando";
        }
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


