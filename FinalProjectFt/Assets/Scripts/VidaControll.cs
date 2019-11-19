using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaControll : MonoBehaviour
{
    public int vida;
     public Text vidatext;
     public Text die;
    // Start is called before the first frame update
    void Start()
    {
        vidatext.text = "Vida : " + vida;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Cyborg")) {
            vida = vida - 5 ;
            vidatext.text = "Vida : " +  vida  ;
            
        }
         StartCoroutine ("reStartlevel");
    } 
    public IEnumerator reStartlevel () {
        if(vida == 0){
        die.text = "Has muerto";
        yield return new WaitForSecondsRealtime (1.0f);
        Application.LoadLevel (Application.loadedLevelName);
        }
    }
}
