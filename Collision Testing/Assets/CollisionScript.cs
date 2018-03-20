using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	int collision = 0;
	double start_time = 0.0;
	double end_time = 0.0;
	double difference = 0.0;
	double timer1 = 0.0;
	double timer2 = 0.0;

	// Use this for initialization
	void Start () {
		print ("Started");

	}
	
	// Update is called once per frame
	void Update () {
		if (collision == 0) {
			transform.position += Vector3.left * Time.deltaTime;
		} else if (collision == 1) {
			transform.position += Vector3.back * Time.deltaTime;
		} else if(collision == 2) {
				transform.position += Vector3.left * Time.deltaTime;
				timer1 = Time.time;
			if (timer1 >= end_time + 3.0) {
				collision = 3;
				timer2 = timer1;
			}
		} else if (collision == 3) {
				transform.position += Vector3.forward * Time.deltaTime; 
			    timer2 += Time.deltaTime;
			if (timer2 >= timer1 + difference) {
				collision = 0;
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		print ("collision");
		if (col.gameObject.name == "Cube") {
			start_time = Time.time;
			//Destroy (col.gameObject);
			collision = 1;
		} 
	}

	void OnCollisionExit(Collision col) {
		end_time = Time.time;
		print ("leaving");
		difference = end_time - start_time;
		print ("difference " + difference);
		col.gameObject.name = "Cube1";
		collision = 2;
	}
}