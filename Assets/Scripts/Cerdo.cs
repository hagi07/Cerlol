using UnityEngine;
using System.Collections;

public class Cerdo : MonoBehaviour {
    public float velocidad;
    public float fuerzaDeSalto;
    public float arriba;
    public float abajo;
    public float izquierda;
    public float derecha;

    public Animator cerdoAnimacion;
    
    private bool saltoOK;
    private bool vidaMenosOk;

    public SpriteRenderer hijo;

    private float velocidadDeMonedas;

    public GameObject Congelar;
    public Animator animadorCongelar;

    public GameObject Quemar;
    public Animator animadorQuemar;

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
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad * Cerebro.TURBO * Cerebro.AUMENTO;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * velocidad * Cerebro.TURBO * Cerebro.AUMENTO;
        transform.Translate(x, 0, y);

        //Establece los límites del juego.
        Limites();

        //Controla el salto del cerdo cuando está en el suelo.
        if (Input.GetKey(KeyCode.Space) && saltoOK)
            rigidbody.velocity = new Vector3(0, fuerzaDeSalto, 0);

        //Establece el cambio de velocidades.
        Velocidades();

        if (Input.GetKey(KeyCode.Q) && (Cerebro.ESTADO == "Jugando" || Cerebro.ESTADO == "RandomEnProceso")) 
        {
            if (PowerUps.eleccion == 1)
            {
                Cerebro.ESTADO = "Atravesando";
                StartCoroutine(WaitVida(6));
                hijo.color = new Color(58f, 182f, 255f, .2f);
            }

            if (PowerUps.eleccion == 2)
            {
                Cerebro.ESTADO = "Escudo";
                cerdoAnimacion.SetBool("BurbujaActivada", true);
                vidaMenosOk = false;
            }

            if (PowerUps.eleccion == 3)
                StartCoroutine(WaitPowerUp(30, "Aspirando"));

            if (PowerUps.eleccion == 4)
                StartCoroutine(WaitSuperCerda());

            if (PowerUps.eleccion == 5)
                StartCoroutine(WaitCongelando());

            if (PowerUps.eleccion == 6)
                StartCoroutine(WaitQuemando());

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
        if (Cerebro.ESTADO == "Atravesando")
            Cerebro.ESTADO = "Jugando";
    }

    IEnumerator WaitPowerUp(int time, string estado)
    {
        Cerebro.ESTADO = estado;
        yield return new WaitForSeconds(time);
        if (Cerebro.ESTADO == estado) 
            Cerebro.ESTADO = "Jugando";
    }

    IEnumerator WaitRandom() 
    {
        Cerebro.ESTADO = "RandomEnProceso";
        yield return new WaitForSeconds(1.5f);
        if (Cerebro.ESTADO == "RandomEnProceso")
            Cerebro.ESTADO = "Jugando";    
    }

    IEnumerator WaitSuperCerda() 
    {
        Cerebro.ESTADO = "Super Cerda";
        cerdoAnimacion.SetBool("DoradoActivada", true);
        vidaMenosOk = false;
        yield return new WaitForSeconds(7);
        if (Cerebro.ESTADO == "Super Cerda")
        {
            Cerebro.ESTADO = "Jugando";
            cerdoAnimacion.SetBool("DoradoActivada", false);
            vidaMenosOk = true;
        }
    }

    IEnumerator WaitCongelando() 
    {
        Cerebro.ESTADO = "Congelar";
        Congelar.gameObject.renderer.enabled = true;
        Congelar.gameObject.collider.enabled = true;
        animadorCongelar.SetBool("Activate", true);
        vidaMenosOk = false;
        yield return new WaitForSeconds(9);
        if (Cerebro.ESTADO == "Congelar") 
        {
            Cerebro.ESTADO = "Jugando";
            Congelar.gameObject.renderer.enabled = false;
            Congelar.gameObject.collider.enabled = false;
            animadorCongelar.SetBool("Activate", false);
            vidaMenosOk = true;
        }
    }

    IEnumerator WaitQuemando() 
    {
        Cerebro.ESTADO = "Quemar";
        Quemar.gameObject.renderer.enabled = true;
        Quemar.gameObject.collider.enabled = true;
        animadorQuemar.SetBool("Activate", true);
        vidaMenosOk = false;
        yield return new WaitForSeconds(8);
        if (Cerebro.ESTADO == "Quemar")
        {
            Cerebro.ESTADO = "Jugando";
            Quemar.gameObject.renderer.enabled = false;
            Quemar.gameObject.collider.enabled = false;
            animadorQuemar.SetBool("Activate", false);
            vidaMenosOk = true;
        }
    }
    
    IEnumerator WaitCharco() 
    {
        Cerebro.AUMENTO = .5f;
        yield return new WaitForSeconds(3);
        if (Cerebro.AUMENTO == .5f)
            Cerebro.AUMENTO = 1;
    }

    IEnumerator WaitLodo()
    {
        Cerebro.AUMENTO = 1.7f;
        yield return new WaitForSeconds(3);
        if (Cerebro.AUMENTO == 1.7f)
            Cerebro.AUMENTO = 1;
    }

    void OnCollisionEnter(Collision other)
    {
        if ((other.gameObject.tag == "1x1" || other.gameObject.tag == "2X2" || other.gameObject.tag == "CaballeroFrontalDel" || other.gameObject.tag == "CaballeroLateralIzq" || other.gameObject.tag == "CaballeroLateralDer" || other.gameObject.tag == "Lanzas" || other.gameObject.tag == "Casa" || other.gameObject.tag == "Roca") && vidaMenosOk && Cerebro.ESTADO != "Super Cerda")
        {
            StartCoroutine(WaitVida(2));
            Cerebro.VIDA--;
            Cerebro.TURBO = 2;
        }

        if (other.gameObject.tag == "PowerUp" && Cerebro.ESTADO == "Jugando")
        {
            StartCoroutine(WaitRandom());
            PowerUps.eleccion = Random.Range(1, 7);
        }

        if (other.gameObject.tag == "Moneda")
            Cerebro.MONEDASConteo++;

        if (other.gameObject.tag == "Cristal")
            Cerebro.CRISTALConteo++;

        if ((other.gameObject.tag == "1x1" || other.gameObject.tag == "2X2" || other.gameObject.tag == "CaballeroFrontalDel" || other.gameObject.tag == "CaballeroLateralIzq" || other.gameObject.tag == "CaballeroLateralDer" || other.gameObject.tag == "Lanzas" || other.gameObject.tag == "Casa" || other.gameObject.tag == "Roca") && !vidaMenosOk && Cerebro.ESTADO == "Escudo")
        {
            cerdoAnimacion.SetBool("BurbujaActivada", false);
            vidaMenosOk = true;
            Cerebro.ESTADO = "Jugando";
        }

        if (other.gameObject.tag == "CharcoVertical" || other.gameObject.tag == "CharcoHorizontal")
        {
            StartCoroutine(WaitCharco());
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

    void Reset()
    {
        Renderer renderer2 = GetComponent<Renderer>();
        renderer2 = GetComponent<MeshRenderer>();
    }
}


