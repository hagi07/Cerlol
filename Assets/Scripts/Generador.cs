using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
    public GameObject secuencia_1_01;
    public GameObject secuencia_1_02;
    public GameObject secuencia_1_03;
    public GameObject secuencia_1_04;
    public GameObject secuencia_1_05;
    public GameObject secuencia_1_06;
    public GameObject secuencia_1_07;
    public GameObject secuencia_1_08;
    public GameObject secuencia_1_09;
    public GameObject[] secuencias;
    public static bool OK;

	void Start () {
        OK = true;
	}

    void Update()
    {
        if (OK && Time.timeScale >= 1) 
        {
            int opcion = Random.Range(0, secuencias.Length);
            Instantiate(secuencias[opcion], this.gameObject.transform.position, Quaternion.identity);
            OK = false;
        } 
    }




}
