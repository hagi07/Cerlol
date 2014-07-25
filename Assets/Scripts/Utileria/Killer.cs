using UnityEngine;
using System.Collections;

public class Killer : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Next")
        {
            Generador.OK = true;
            other.BroadcastMessage("Destruyete", SendMessageOptions.RequireReceiver);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
    }
}
