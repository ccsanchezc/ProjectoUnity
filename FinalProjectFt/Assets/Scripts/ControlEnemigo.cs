using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlEnemigo : MonoBehaviour
{
    Transform posicionJugador;
    NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag ("Jugador").transform;
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(posicionJugador.position);
    }
}
