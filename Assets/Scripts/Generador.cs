using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
    public GameObject roca;
    public GameObject secuencia_1_01;
    public GameObject secuencia_1_03;
    private bool OK;

	void Start () {
        OK = true;
	}

    void Update()
    {
        if (OK) 
        {
            int opcion = Random.RandomRange(0, 3);
            switch (opcion)
            {
                case 0: Instantiate(secuencia_1_01, this.gameObject.transform.position, Quaternion.identity);
                        StartCoroutine(Wait(9));
                        break;
                case 1: Instantiate(secuencia_1_03, this.gameObject.transform.position, Quaternion.identity);
                        StartCoroutine(Wait(7));
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
