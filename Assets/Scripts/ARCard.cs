using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Vuforia;
public enum CardPose {DEFAULT, ATTACK, DEFENSE, DESTROYED};

public class ARCard : MonoBehaviour
{
    public CardPose pose = CardPose.DEFAULT;

    public ImageTargetBehaviour target; // componente del image target

    public int ATK = 0;
    public int DEF = 0;

    public TextMeshPro textoATK; 
    public TextMeshPro textoDEF;
    public GameObject botonATK;
    public GameObject botonDEF;
    public GameObject spriteDEF;
    public GameObject modeloATK;
    public GameObject spriteDestuido;
    public GameObject indicadorJ1;
    public GameObject indicadorJ2;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<ImageTargetBehaviour>();
        pose = CardPose.DEFAULT;
        ActualizaTextos();
        ActualizaSegunEstado();
    }
    // Update is called once per frame
    void Update()
    {
      /*  if (target.TargetStatus.Status == Status.NO_POSE)
        {
            Debug.Log("el target " + target.TargetName + "no está en la pantalla");
        }
        else // El target esta recoconocido
        {
            Debug.Log("el target" + target.TargetName + "aparece");
        }
      */
    }
    public void ResetCarta()
    {
        pose = CardPose.DEFAULT;    // Cambiamos estado
        ActualizaSegunEstado ();    // Actualizamos objetos hijos
        indicadorJ1.SetActive (false);  //Apagamos indicadores de propietario
        indicadorJ2.SetActive (false);
    }

    public Status GetStatus()
    {
        return target.TargetStatus.Status;
    }
    public int GetCardStat()
    {
        /*if (pose == CardPose.ATTACK)
        {
            return ATK;
        }
        else if (pose == CardPose.DEFENSE)
        {
            return DEF;
        }
        else return -1; */// Otros estados
        // version con operador ternario
        // (condicion entre parentesis) ? (código que se hace si es true) : (código que se hace si es false);
        return (pose == CardPose.ATTACK) ? ATK : DEF;
    }
    private void ActualizaTextos()
    {
        textoATK.text = "ATK: \n" + ATK.ToString();
        textoDEF.text = "DEF: \n" + DEF.ToString();
    }
    public void PonPosicionAtaque()
    {
        Debug.Log("Ataque");
        pose = CardPose.ATTACK; // Cambia el estado de la carta
        ActualizaSegunEstado();
    }
    public void PonPosicionDefensa()
    {
        Debug.Log("Defensa");
        pose = CardPose.DEFENSE; // Cambia el estado de la carta
        ActualizaSegunEstado();
    }
    public void PonEstado(CardPose estado)
    {
        pose = estado;
        ActualizaSegunEstado();
    }
    public void PonPosicionDestruido()
    {
        pose = CardPose.DESTROYED; // Cambia el estado de la carta
        ActualizaSegunEstado();
    }
    private void  ActualizaSegunEstado()
    {
        switch (pose)
        {
            case CardPose.DEFAULT:
                botonATK.SetActive(true); 
                botonDEF.SetActive(true);
                modeloATK.SetActive(false);
                spriteDEF.SetActive(false);
                spriteDestuido.SetActive(false);
                break;
            case CardPose.ATTACK:
                botonATK.SetActive(false);
                botonDEF.SetActive(false);
                modeloATK.SetActive(true);
                spriteDEF.SetActive(false);
                spriteDestuido.SetActive(false);
                break;
            case CardPose.DEFENSE:
                botonATK.SetActive(false);
                botonDEF.SetActive(false);
                modeloATK.SetActive(false);
                spriteDEF.SetActive(true);
                spriteDestuido.SetActive(false);
                break;
            case CardPose.DESTROYED:
                botonATK.SetActive(false);
                botonDEF.SetActive(false);
                modeloATK.SetActive(false);
                spriteDEF.SetActive(false);
                spriteDestuido.SetActive(true);
                break;
        }
    }
    public void AsignaPropietario(bool j2)
    {
        indicadorJ1.SetActive(!j2);
        indicadorJ2.SetActive(j2);

        if (j2) 
        {
            indicadorJ1.SetActive(false);
            indicadorJ2.SetActive(true);
        }

        else
        {
            indicadorJ1.SetActive(true);
            indicadorJ2.SetActive(false);
        }
    }
}
