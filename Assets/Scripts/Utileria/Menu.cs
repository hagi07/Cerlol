using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    private bool ok;
    private Vector3 escalaInicial;
    private Vector3 escalaFinal;

    public static bool settings;
    public static bool shop;

	void Start () {
        ok = false;
        escalaInicial = transform.localScale;
        escalaFinal = new Vector3(transform.localScale.x * 1.2f, transform.localScale.y * 1.2f, transform.localScale.z * 1.2f);
        settings = false;
        shop = false;
    }
	
	
	void Update () {
        if (Time.timeScale == 0)
        {
            this.gameObject.renderer.enabled = true;
            if(collider != null) this.gameObject.collider.enabled = true;
        }
        else if (Application.loadedLevelName == "Main")
        {
            this.gameObject.renderer.enabled = false;
            if (collider != null) this.gameObject.collider.enabled = false;
        }

        if (Application.loadedLevelName == "Principal")
            this.gameObject.renderer.enabled = true;

        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Escape))
            Time.timeScale = 1;
	}

    void OnMouseDown() 
    {
        if(this.gameObject.name == "Continue")
            Time.timeScale = 1;

        if (this.gameObject.name == "Settings")
            settings = true;

        if (this.gameObject.name == "Retry")
        {
            Time.timeScale = 1;
            Application.LoadLevel("Main");
        }

        if (this.gameObject.name == "Main Menu")
        {
            Time.timeScale = 1;
            Application.LoadLevel("Principal");
        }

        //MENU PRINCIPAL

        if (this.gameObject.name == "Play")
        {
            Application.LoadLevel("Main");
        }

        if (this.gameObject.name == "Shop")
        {
            shop = !shop;
        }

        if (this.gameObject.name == "MoreGames")
        {
            Application.OpenURL("http://www.elyongames.com/");
        }

        if (this.gameObject.name == "Quit")
        {
            Application.Quit();
        }

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
