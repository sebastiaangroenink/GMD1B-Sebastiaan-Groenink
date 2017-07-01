using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecay : MonoBehaviour {

    public float decayTimer = 3.0f;


    void Update()
    {
        DecayTimer();
    }

    void DecayTimer() { //destroys spell after set time.
    decayTimer -= 1 * Time.deltaTime;

        if(decayTimer< 0)
        {
            Destroy(gameObject);
        }
	}
}
