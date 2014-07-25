using UnityEngine;
using System.Collections;

public class MovimientodeObjetos : MonoBehaviour {
    private bool muevete;
    public SpriteRenderer hielo;
    public Animator objetoAnimacion;
    public GameObject cenizas;
    public GameObject hieloRoto;

	void Start () {
        muevete = true;
	}

    void Update()
    {
        if (muevete)
        {
            if (this.gameObject.tag == "CaballeroFrontalDel")
                transform.Translate(0, 0, Cerebro.VELOCIDAD * Cerebro.TURBO * Cerebro.AUMENTO * Time.deltaTime * 1.2f);
            else
                transform.Translate(0, 0, Cerebro.VELOCIDAD * Cerebro.TURBO * Cerebro.AUMENTO * Time.deltaTime);  
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Player" && Cerebro.ESTADO == "Super Cerda") 
        {
            muevete = false;
            this.gameObject.rigidbody.useGravity = false;
            this.gameObject.collider.isTrigger = true;
            this.rigidbody.velocity = new Vector3(0,50,-30);
            
        }

        if (other.gameObject.tag == "Player" && Cerebro.ESTADO == "Congelar") 
        {
            Instantiate(hieloRoto, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "RayoCongelante" && Cerebro.ESTADO == "Congelar")
        {
            hielo.renderer.enabled = true;
            if (animation != null)
                objetoAnimacion.speed = 0;
        }

        if (other.gameObject.tag == "RayoQuemador" && Cerebro.ESTADO == "Quemar" && cenizas != null)
        {
            Instantiate(cenizas,this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        
    }

}
