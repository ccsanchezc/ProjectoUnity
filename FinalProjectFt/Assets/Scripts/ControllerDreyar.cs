using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDreyar : MonoBehaviour {
    public Text die;
    private Animator anim;
    public ParticleSystem poderPiso;
    public GameObject poder;//Poder
    private AudioSource Audio; // AudioObjeto
     public AudioClip DisparoClip; // DisparoClip
     GameObject buttonSave;
     GameObject buttonLoad;
    // Start is called before the first frame update
    void Start () {
        Audio =  GetComponent<AudioSource>();
        poderPiso.Stop();
        die.text = "";
        buttonSave = GameObject.Find("ButtonSave");
        buttonLoad = GameObject.Find("ButtonLoad");
        // buttonSave = GameObject.Find("Canvas").transform.getChild(0).gameObject.SetActive(false);
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
        yield return new WaitForSeconds(0.1f);
        Audio.clip = DisparoClip;
        Audio.Play();
        poder.transform.position = transform.position;
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
        // buttonSave.SetActive(false);
        // buttonLoad.SetActive(false);
        Debug.Log ("El jugador cayó al vació");
        die.text = "Has muerto";
        yield return new WaitForSecondsRealtime (10.0f);
        Application.LoadLevel (Application.loadedLevelName);
    }
}