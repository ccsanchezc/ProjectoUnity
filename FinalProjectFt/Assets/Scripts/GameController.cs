using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController control;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void awake(){
        if(control == null){
            DontDestroyOnLoad(gameObject);
            control = this;
        }else if(control != this){
            Destroy(gameObject);
        }
    }

    public void Guardar(){
        BinaryFormatter fb = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath+"/persistencia.dat");
        DatosJuego datos = new DatosJuego();
        Debug.Log(""+Application.persistentDataPath);
        datos.posx = GameObject.Find("ThirdPersonController").transform.position.x;
        datos.posy = GameObject.Find("ThirdPersonController").transform.position.y;
        datos.posz = GameObject.Find("ThirdPersonController").transform.position.z;
        fb.Serialize(file, datos);
        file.Close();
    }

    public void Cargar(){
        if(File.Exists(Application.persistentDataPath+"/persistencia.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+"/persistencia.dat", FileMode.Open);
            DatosJuego datos = (DatosJuego) bf.Deserialize(file);
            file.Close();

            Vector3 posicion = new Vector3(datos.posx, datos.posy, datos.posz);
            GameObject.Find("ThirdPersonController").transform.position = posicion;
        }
    }
}

[Serializable]
class DatosJuego{
    public float posx;
    public float posy;
    public float posz;
}