using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Barra")]
    [SerializeField] private Image vidaPlayer;
    [Header("Texto")]
    [SerializeField] private TextMeshProUGUI vidaTMP;

    private float vidaActual;
    private float vidaMax;

    void Update()
    {
        ActualizarUIPersonaje();
        
    }
     private void ActualizarUIPersonaje()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, 
            vidaActual / vidaMax, 10f * Time.deltaTime);
        
        vidaTMP.text = $"{vidaActual}/{vidaMax}";
        
    }

    public void ActualizarVidaPersonaje(float pVidaActual, float pVidaMax)
    {
        vidaActual = pVidaActual;
        vidaMax = pVidaMax;
    }
    
}
