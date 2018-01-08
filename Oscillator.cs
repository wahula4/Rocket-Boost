using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // prevents you from adding the same script to an object multiple times
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    float movementFactor; // 0 for not moved,  for fully moved
    Vector3 startingPos;

    // Use this for initialization
    void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // Mathf.Epsilon is the lowest value available. we are protecting against NaN with a period of 0
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2; // 6.28 which is twice pi
        float rawSineWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSineWave / 2f + 0.5f;

        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
	}
}
