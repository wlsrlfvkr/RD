using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsEnemy : MonoBehaviour {

	public float speed = 10f;

	private Transform target;
	private int wavePointIndex;

	void Start () { 
		
		target = CsWayPoint.points [0];

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime,Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f) {
			GetNextWaypoint ();
		}

	}

	void GetNextWaypoint() {
		if (wavePointIndex >= CsWayPoint.points.Length - 1) {
			Destroy (gameObject);
			return;
		}
		wavePointIndex++;
		target = CsWayPoint.points [wavePointIndex];
	}
}
