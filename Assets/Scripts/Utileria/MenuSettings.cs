using UnityEngine;
using System.Collections;

public class MenuSettings : MonoBehaviour {
    private bool ok;
    private Vector3 escalaInicial;
    private Vector3 escalaFinal;

	void Start () {
        ok = false;
        escalaInicial = transform.localScale;
        escalaFinal = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, transform.localScale.z * 1.2f);
	}

    void Update()
    {
        if (Menu.settings)
        {
            renderer.enabled = true;
            if (collider != null) collider.enabled = true;
        }
        else
        {
            renderer.enabled = false;
            if (collider != null) collider.enabled = false;
        }

        if (Menu.settings && Input.GetKeyDown(KeyCode.Escape))
            Menu.settings = false;
    }

    void OnMouseDown() 
    {
        if (this.renderer.name == "Return")
            Menu.settings = false;
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
