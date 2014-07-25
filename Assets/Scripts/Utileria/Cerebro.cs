using UnityEngine;
using System.Collections;

public class Cerebro : MonoBehaviour {
    public static string ESTADO;
    public static int VIDA;
    public static int TURBO;
    public static float AUMENTO;
    public static int MONEDASConteo;
    public static int CRISTALConteo;
    public static int METROS;

    public static GameObject MONEDA;
    public static GameObject CRISTAL;
    public static GameObject[] OBSTACULOS1X1;
    public static GameObject[] OBSTACULOS2X2;
    public static GameObject POWERUP;
    public static GameObject CABALLEROFRONTALDELANTERO;
    public static GameObject CABALLEROFLATERALIZQUIERDO;
    public static GameObject CABALLEROFLATERALDERECHO;

    public GameObject moneda;
    public GameObject cristal;
    public GameObject[] obstaculos1x1;
    public GameObject[] obstaculos2x2;
    public GameObject powerUp;
    public GameObject caballeroFrontalDelantero;
    public GameObject caballeroLateralDerecho;
    public GameObject caballeroLateralIzquierdo;

    public float velocidadGeneral;
    public static float VELOCIDAD;

    private bool vaciadoDeInformacion;
    

	void Start () {
        ESTADO = "Jugando";
        VIDA = 4;
        TURBO = 2;
        MONEDASConteo = 0;
        CRISTALConteo = 0;
        AUMENTO = 1;
        METROS = 0;

        MONEDA = moneda;
        CRISTAL = cristal;
        OBSTACULOS1X1 = obstaculos1x1;
        OBSTACULOS2X2 = obstaculos2x2;
        POWERUP = powerUp;
        CABALLEROFRONTALDELANTERO = caballeroFrontalDelantero;
        CABALLEROFLATERALDERECHO = caballeroLateralDerecho;
        CABALLEROFLATERALIZQUIERDO = caballeroLateralIzquierdo;

        vaciadoDeInformacion = true;
	}

	void Update () {
        VELOCIDAD = velocidadGeneral;

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
        
        if(TURBO > 0)   METROS = (int)Time.timeSinceLevelLoad * 2 * TURBO;

        Debug.Log(METROS);
	}

    IEnumerator Wait()
    {
        if (vaciadoDeInformacion)
        {
            int monedas = PlayerPrefs.GetInt("MonedasTotales");
            int cristales = PlayerPrefs.GetInt("CristalesTotales");
            int metros = PlayerPrefs.GetInt("MetrosTotales");
            int bestScore = PlayerPrefs.GetInt("BestScore");

            Debug.Log(monedas);

            PlayerPrefs.SetInt("MonedasTotales", monedas += MONEDASConteo);
            PlayerPrefs.SetInt("CristalesTotales", cristales += CRISTALConteo);
            PlayerPrefs.SetInt("MetrosTotales", metros += METROS);
            if (bestScore < METROS) PlayerPrefs.SetInt("BestScore", METROS);

            vaciadoDeInformacion = false;
        }
        yield return new WaitForSeconds(1);
        ESTADO = "Game Over";
    }
}
