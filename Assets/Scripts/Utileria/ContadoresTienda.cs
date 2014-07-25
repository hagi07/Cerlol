using UnityEngine;
using System.Collections;

public class ContadoresTienda : MonoBehaviour {
    public bool millarMonedasTag;
    public bool centenaMonedasTag;
    public bool decenaMonedasTag;
    public bool unidadMonedasTag;

    private int millarMonedas;
    private int centenaMonedas;
    private int decenaMonedas;
    private int unidadMonedas;

    private int monedas;

    public Material[] material;

	void Start () {
       
	}
	

	void Update () {
        ContadorMonedas();
	}
    void ContadorMonedas()
    {
        int monedastotales = PlayerPrefs.GetInt("MonedasTotales");
        //Establece los parámetros de la decena y la unidad.
        millarMonedas = (monedastotales / 1000);
        centenaMonedas = (monedastotales / 100) - millarMonedas * 10;
        decenaMonedas = (monedastotales / 10) - (centenaMonedas * 10) - (millarMonedas * 100);
        unidadMonedas = monedastotales - (decenaMonedas * 10) - (centenaMonedas * 100) - (millarMonedas * 1000);

        //Hace el cambio de valor global dependiendo si es unidad o decena.
        if (millarMonedasTag)
            monedas = millarMonedas;

        if (centenaMonedasTag)
            monedas = centenaMonedas;

        if (decenaMonedasTag)
            monedas = decenaMonedas;

        if (unidadMonedasTag)
            monedas = unidadMonedas;

        //Hace el cambio de textura.
        if (unidadMonedasTag || decenaMonedasTag || centenaMonedasTag || millarMonedasTag)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Transparent Cutout");
            gameObject.renderer.material = material[monedas];
        }
    }
}
