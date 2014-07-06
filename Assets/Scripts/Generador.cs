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
    public static bool OK;

	void Start () {
        OK = true;
	}

    void Update()
    {
        if (OK && Time.timeScale >= 1) 
        {
            int opcion = Random.RandomRange(0, 10);
            switch (opcion)
            {
                case 0: Instantiate(secuencia_1_01, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 1: Instantiate(secuencia_1_02, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 3: Instantiate(secuencia_1_03, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 4: Instantiate(secuencia_1_04, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 5: Instantiate(secuencia_1_05, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 6: Instantiate(secuencia_1_06, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 7: Instantiate(secuencia_1_07, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 8: Instantiate(secuencia_1_08, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break;
                case 9: Instantiate(secuencia_1_09, this.gameObject.transform.position, Quaternion.identity);
                        OK = false;
                        break; 
            }
            Debug.Log(opcion);
        } 
    }

    IEnumerator Wait(int time)
    {
        OK = false;
        //yield return new WaitForSeconds(Random.RandomRange(100,110));
        yield return new WaitForSeconds(time);
        OK = true;
    }




}
