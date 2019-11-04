using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResistencia : MonoBehaviour {
     public int resistencia;
     private AudioSource Audio; // AudioObjeto
     public AudioClip Impacto; // DisparoClip
    public void RegistrarImpacto (Vector3 puntoImpacto) {
        Debug.Log("Resistencia: "+resistencia);
        resistencia--;
        if (resistencia <= 0) {
            Destroy (transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start () {
           Audio =  GetComponent<AudioSource>();
           Audio.clip = Impacto;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnParticleCollision(GameObject other){
        resistencia--;
         Audio.Play();
        Debug.Log("Colionó "+resistencia);
        if (resistencia <= 0) {
            
            Destroy (transform.gameObject);
        }
    }
}