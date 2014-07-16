using UnityEngine;
using System.Collections;

public class Cerebro : MonoBehaviour {
    public static string ESTADO;
    public static int VIDA;
    public static int TURBO;
    public static int MONEDAS;
    public static int CRISTAL;
    
    void Awake() 
    {
        ESTADO = "Jugando";
        VIDA = 3;
        TURBO = 2;
        MONEDAS = 0;
        CRISTAL = 0;
    }

	void Start () {
	
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) 
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;


        if (VIDA == 0)
        {
            StartCoroutine(Wait());
            TURBO = 0;
        }

        Debug.Log("ESTADO: " + ESTADO);
        Debug.Log("Eleccion: " +  PowerUps.eleccion);

        
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Main");
    }
}
