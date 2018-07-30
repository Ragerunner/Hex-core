using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public Hex currentHex;
    public Vector3 destination;
    public Vector3 y_offset;
    float speed = 2;

	// Use this for initialization
	void Start () {
        destination = transform.position - y_offset;
	}
	
	// Update is called once per frame
	void Update () {
        // move towards our destination
        Vector3 dir = destination - transform.position+ y_offset;
        Vector3 velocity = dir.normalized * speed * Time.deltaTime;
        // make sure the velocity doesnt actually exceed the distance we want.

        velocity = Vector3.ClampMagnitude(velocity, dir.magnitude);

        transform.Translate(velocity);

    }
}
