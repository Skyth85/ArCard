using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ARButton : MonoBehaviour
{
    public MusicManager mm;
    public AudioClip SonidoBoton;
    public UnityEvent action; // Variable que permite asignar una función 
    // Start is called before the first frame update
    void Start()
    {
        mm = MusicManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()  // Se llama al hacer click sobre este objeto
    {
        Debug.Log("Detecta Boton");
        action.Invoke(); // Llama a la función de action
        mm.PlaySFX(SonidoBoton);
    }
}
