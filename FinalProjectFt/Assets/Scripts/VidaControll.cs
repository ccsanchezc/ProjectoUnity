using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaControll : MonoBehaviour
{
    public int vida;
     public Text vidatext;
    // Start is called before the first frame update
    void Start()
    {
        vidatext.text = "Vida : " + vida;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
