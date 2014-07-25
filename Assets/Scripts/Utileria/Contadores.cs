using UnityEngine;
using System.Collections;

public class Contadores : MonoBehaviour {
    //Variables de Metros.
    public bool decenaMillarMetrosTag;
    public bool millarMetrosTag;
    public bool centenaMetrosTag;
    public bool decenaMetrosTag;
    public bool unidadMetrosTag;

    private int decenaMillarMetros;
    private int millarMetros;
    private int centenaMetros;
    private int decenaMetros;
    private int unidadMetros;

    int metros;
    
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
    public bool millarCristalTag;
    public bool centenaCristalTag;
    public bool decenaCristalTag;
    public bool unidadCristalTag;

    private int millarCristal;
    private int centenaCristal;
    private int decenaCristal;
    private int unidadCristal;

    private int cristal;

    //Texturas
    public Material[] material;

    Object[] TEXTURES;


    void Start()
    {
        monedas = 0;
        cristal = 0;
        metros = 0;
    }

    void Update()
    {
        ContadorMonedas();
        ContadorCristales();
        ContadorMetros();
    }

    void ContadorMonedas() 
    {
        //Establece los parámetros de la decena y la unidad.
        millarMonedas = (Cerebro.MONEDASConteo / 1000);
        centenaMonedas = (Cerebro.MONEDASConteo / 100) - millarMonedas * 10;
        decenaMonedas = (Cerebro.MONEDASConteo / 10) - (centenaMonedas * 10) - (millarMonedas * 100);
        unidadMonedas = Cerebro.MONEDASConteo - (decenaMonedas * 10) - (centenaMonedas * 100) - (millarMonedas * 1000);

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

    void ContadorCristales()
    {
        //Establece los parámetros de la decena y la unidad.
        millarCristal = (Cerebro.CRISTALConteo / 1000);
        centenaCristal = (Cerebro.CRISTALConteo / 100) - (millarCristal * 10);
        decenaCristal = (Cerebro.CRISTALConteo / 10) - (centenaCristal * 10) - (millarCristal * 100);
        unidadCristal = Cerebro.CRISTALConteo - (decenaCristal * 10) - (centenaCristal * 100) - (millarCristal * 1000); 

        //Hace el cambio de valor global dependiendo si es unidad o decena.
        if (millarCristalTag)
            cristal = millarCristal;

        if (centenaCristalTag)
            cristal = centenaCristal;

        if (decenaCristalTag)
            cristal = decenaCristal;

        if (unidadCristalTag)
            cristal = unidadCristal;

        //Hace el cambio de textura.
        if (unidadCristalTag || decenaCristalTag || centenaCristalTag || millarCristalTag)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Transparent Cutout");
            gameObject.renderer.material = material[cristal];
        }
    }

    void ContadorMetros()
    {
        //Establece los parámetros de la decena y la unidad.
        decenaMillarMetros = (Cerebro.METROS / 10000);
        millarMetros = (Cerebro.METROS / 1000) - (decenaMillarMetros * 10);
        centenaMetros = (Cerebro.METROS / 100) - (millarMetros * 10) - (decenaMillarMetros * 100);
        decenaMetros = (Cerebro.METROS / 10) - (centenaMetros * 10) - (millarMetros * 100) - (decenaMillarMetros * 1000);
        unidadMetros = Cerebro.METROS - (decenaMetros * 10) - (centenaMetros * 100) - (millarMetros * 1000) - (decenaMillarMetros * 10000);

        //Hace el cambio de valor global dependiendo si es unidad o decena.
        if (decenaMillarMetrosTag)
            metros = decenaMillarMetros;

        if (millarMetrosTag)
            metros = millarMetros;

        if (centenaMetrosTag)
            metros = centenaMetros;

        if (decenaMetrosTag)
            metros = decenaMetros;

        if (unidadMetrosTag)
            metros = unidadMetros;

        //Hace el cambio de textura.
        if (unidadMetrosTag || decenaMetrosTag || centenaMetrosTag || millarMetrosTag || decenaMillarMetrosTag)
        {
            gameObject.renderer.material.shader = Shader.Find("Unlit/Transparent Cutout");
            gameObject.renderer.material = material[metros];
        }
    }
}
