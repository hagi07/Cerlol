using UnityEngine;
using System.Collections;

public class Contadores : MonoBehaviour {
    //Variables de Monedas.
    public bool millarMonedasTag;
    public bool centenaMonedasTag;
    public bool decenaMonedasTag;
    public bool unidadMonedasTag;
    
    private int millarMonedas;
    private int centenaMonedas;
    private int decenaMonedas;
    private int unidadMonedas;

    int monedas;

    //Variables de Cristales.
    public bool centenaCristalTag;
    public bool decenaCristalTag;
    public bool unidadCristalTag;

    private int centenaCristal;
    private int decenaCristal;
    private int unidadCristal;

    private int cristal;

    //Texturas
    public Texture2D[] textura;

    void Start()
    {
        monedas = 0;
        cristal = 0;
    }

    void Update()
    {
        ContadorMonedas();
        ContadorCristales();
    }

    void ContadorMonedas() 
    {
        //Establece los parámetros de la decena y la unidad.
        millarMonedas = (Cerebro.MONEDAS / 1000);
        centenaMonedas = (Cerebro.MONEDAS / 100) - millarMonedas *10;
        decenaMonedas = (Cerebro.MONEDAS / 10) - (centenaMonedas * 10) - (millarMonedas * 100);
        unidadMonedas = Cerebro.MONEDAS - (decenaMonedas * 10) - (centenaMonedas * 100) - (millarMonedas * 1000);

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
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[monedas];
        }
    }

    void ContadorCristales()
    {
        //Establece los parámetros de la decena y la unidad.
        centenaCristal = (Cerebro.CRISTAL / 100);
        decenaCristal = (Cerebro.CRISTAL / 10) - (centenaCristal * 10);
        unidadCristal = Cerebro.CRISTAL - (decenaCristal * 10) - (centenaCristal * 100);

        //Hace el cambio de valor global dependiendo si es unidad o decena.
        if (centenaCristalTag)
            cristal = centenaCristal;

        if (decenaCristalTag)
            cristal = decenaCristal;

        if (unidadCristalTag)
            cristal = unidadCristal;

        //Hace el cambio de textura.
        if (unidadCristalTag || decenaCristalTag || centenaCristalTag)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Texture");
            gameObject.renderer.material.mainTexture = textura[cristal];
        }
    }
}
