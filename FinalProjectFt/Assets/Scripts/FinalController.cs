using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Jugador"){
            StartCoroutine("changeScene");
            Debug.Log("Gano");
        }
    }

    IEnumerator changeScene(){
        Debug.Log("Recolectables is empty");
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene(1);
    }
}
