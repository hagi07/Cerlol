using UnityEngine;
using System.Collections;

public class Cerebro : MonoBehaviour {
    public static string ESTADO;
    public static int VIDA;

    void Awake() 
    {
        ESTADO = "Jugando";
        VIDA = 3;
    }

	void Start () {
	
	}
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        if (VIDA == 0)
            StartCoroutine(Wait());
        
	}

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Application.LoadLevel("Main");
    }
}
