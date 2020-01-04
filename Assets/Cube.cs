using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

    public bool blowUp;
    public ParticleSystem explosion;

    public void BlowUp()
    {
        explosion.Play();
    }
}
