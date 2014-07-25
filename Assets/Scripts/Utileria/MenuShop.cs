using UnityEngine;
using System.Collections;

public class MenuShop : MonoBehaviour {
    private bool ok;
    private Vector3 escalaInicial;
    private Vector3 escalaFinal;

	void Start () {
        ok = false;
        escalaInicial = transform.localScale;
        escalaFinal = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, transform.localScale.z * 1.2f);
	}
	
	void Update () {
        if (Menu.shop)
        {
            renderer.enabled = true;
            if (collider != null) collider.enabled = true;
        }
        else
        {
            renderer.enabled = false;
            if (collider != null) collider.enabled = false;
        }
	}

    void OnMouseDown()
    {
        if (this.gameObject.name == "Clear") 
        {
            PlayerPrefs.SetInt("MonedasTotales", 0);
            PlayerPrefs.SetInt("CristalesTotales", 0);
            PlayerPrefs.SetInt("MetrosTotales", 0);
            PlayerPrefs.SetInt("BestScore", 0);
        }

        if (this.gameObject.name == "Return")
            Menu.shop = false;
    }

    void OnMouseOver()
    {
        this.gameObject.transform.localScale = escalaFinal;
        ok = true;
    }

    void OnMouseExit()
    {
        if (ok)
            this.gameObject.transform.localScale = escalaInicial;
    }
}
