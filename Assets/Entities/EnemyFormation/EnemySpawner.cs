using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;

    float xmin;
    float xmax;
    public float padding = 1f;
    public float speed = 5f;

    // Use this for initialization
    void Start()
    { 

        foreach(Transform child in transform){
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + width/2;
        xmax = rightmost.x  - width/2;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // Update is called once per frame
    void Update() { 

        transform.position += Vector3.right* speed * Time.deltaTime;
   

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        if (transform.position.x == xmin || transform.position.x == xmax) { speed = -speed; }
        
		
	}
}
