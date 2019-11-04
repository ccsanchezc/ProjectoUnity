using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResistencia : MonoBehaviour {
    public int resistencia;

    public void RegistrarImpacto (Vector3 puntoImpacto) {
        Debug.Log("Resistencia: "+resistencia);
        resistencia--;
        if (resistencia <= 0) {
            Destroy (transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnParticleCollision(GameObject other){
        resistencia--;
        Debug.Log("Colionó "+resistencia);
        if (resistencia <= 0) {
            Destroy (transform.gameObject);
        }
    }
}