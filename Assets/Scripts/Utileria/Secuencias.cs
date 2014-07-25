using UnityEngine;
using System.Collections;

public class Secuencias : MonoBehaviour {

    //Solo para NEXT
    public GameObject padre;

	void Start () {
	
	}
	
	void Update () {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Transformador")
        {
            if (gameObject.tag == "1x1")
            {
                Instantiate(Cerebro.OBSTACULOS1X1[Random.Range(0,Cerebro.OBSTACULOS1X1.Length)], this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "2x2")
            {
                Instantiate(Cerebro.OBSTACULOS2X2[Random.Range(0, Cerebro.OBSTACULOS2X2.Length)], this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            
            if (gameObject.tag == "Moneda")
            {
                Instantiate(Cerebro.MONEDA, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "Cristal")
            {
                Instantiate(Cerebro.CRISTAL, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "PowerUp")
            {
                Instantiate(Cerebro.POWERUP, this.gameObject.transform.position - new Vector3(0,3,0), Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "CaballeroFrontalDel")
            {
                Instantiate(Cerebro.CABALLEROFRONTALDELANTERO, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "CaballeroLateralIzq")
            {
                Instantiate(Cerebro.CABALLEROFLATERALIZQUIERDO, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

            if (gameObject.tag == "CaballeroLateralDer")
            {
                Instantiate(Cerebro.CABALLEROFLATERALDERECHO, this.gameObject.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }   
        }    
    }

    void Destruyete() 
    {
        Destroy(padre.gameObject);
    }
}
