using UnityEngine;
using System.Collections;

public class Topo : MonoBehaviour {
    public Animator topoAnimado;
    

	void Start () {
	}
	
	void Update () {
        Collider[] hit = Physics.OverlapSphere(this.gameObject.transform.position, 4);
        for (int i = 0; i < hit.Length; i++)
            if (hit[i].tag == "Player")
                topoAnimado.SetBool("Activate", true);
	}

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
            topoAnimado.SetBool("Muerto", true);
    }

    void Reset()
    {
        Renderer renderer2 = GetComponent<Renderer>();
        renderer2 = GetComponent<MeshRenderer>();
    }
}
