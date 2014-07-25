using UnityEngine;
using System.Collections;

public class Charcos : MonoBehaviour {
    public Animator animator;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player")
            animator.SetBool("Activate", true);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            animator.SetBool("Activate", true);
    }

    void Reset()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer = GetComponent<MeshRenderer>();
    }
}
