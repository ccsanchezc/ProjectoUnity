using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDreyar : MonoBehaviour {
    public Text die;
    private Animator anim;
    public ParticleSystem poderPiso;
    // Start is called before the first frame update
    void Start () {
        die.text = "";
        anim = GetComponent<Animator> ();
    }
    // Update is called once per frame
    void Update () {
        if(Input.GetButton("Fire1")){
            LanzarPoder();
        }
        // transform.rotate(0,x)

    }

    public void LanzarPoder(){
        StartCoroutine("LanzaPoderCoRoutine");
    }

    public IEnumerator LanzaPoderCoRoutine(){
        anim.SetBool("LanzarMagia",true);
        yield return new WaitForSeconds(0.5f);
        poderPiso.Play();
        StartCoroutine("DetenerPoder");
        anim.SetBool("LanzarMagia",false);
    }

    public IEnumerator DetenerPoder(){
        yield return new WaitForSecondsRealtime(2.0f);
        poderPiso.Stop();
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("DiePlane")) {
            StartCoroutine ("reStartlevel");
        }
    }

    public IEnumerator reStartlevel () {
        Debug.Log ("El jugador cayó al vació");
        die.text = "Has muerto";
        yield return new WaitForSecondsRealtime (10.0f);
        Application.LoadLevel (Application.loadedLevelName);
    }
}