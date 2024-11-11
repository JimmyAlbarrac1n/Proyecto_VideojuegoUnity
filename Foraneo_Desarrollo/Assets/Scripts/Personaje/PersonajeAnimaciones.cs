using System;
using UnityEngine;

public class PersonajeAnimaciones : MonoBehaviour
{
   [SerializeField] private string layerIdle;
   [SerializeField] private string layerCaminar;
    
    private Animator _animator;
    private PersonajeMovimiento _personajeMovimiento;

    //En lugar de poner x en varios lugares, usamos el hash de direccion X
    private readonly int direccionX = Animator.StringToHash("x");
    private readonly int direccionY = Animator.StringToHash("y");
    private readonly int derrotado = Animator.StringToHash("Derrotado");
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PersonajeMovimiento>();
    }

    private void Update()
    {
       ActualizarLayers();
        //Si el personaje no se mueve queda en su estado
        if (_personajeMovimiento.EnMovimiento == false)
        {
            return;
        }
        
        _animator.SetFloat(direccionX, _personajeMovimiento.DireccionMovimiento.x);
        _animator.SetFloat(direccionY, _personajeMovimiento.DireccionMovimiento.y);
    }

    //Poner un peso a los layers
    private void ActivarLayer(string nombreLayer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        
        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), 1);
    }


    private void ActualizarLayers()
    {
        if (_personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(layerCaminar);
        }
        else
        {
            ActivarLayer(layerIdle);   
        }
    }
  
    public void RevivirPersonaje()
    {
        ActivarLayer(layerIdle);
        _animator.SetBool(derrotado, false);
    }
    
    private void PersonajeDerrotadoRespuesta()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1)
        {
            _animator.SetBool(derrotado, true);
        }
    }
  
    
    private void OnEnable()
    {
        PersonajeVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }

    private void OnDisable()
    {
        PersonajeVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;
    }
}
