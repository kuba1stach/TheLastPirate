using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleSpawner : MonoBehaviour {

    public GameObject Pole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Pole, transform.position, Quaternion.identity);
        }
	}
}
