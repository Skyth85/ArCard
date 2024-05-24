using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TextoSlider : MonoBehaviour
{
    public Slider slider;
    private TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        ActualizaTexto();
    }

    public void ActualizaTexto()
    {
        Debug.Log("Texto Actualizado");
        texto.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
