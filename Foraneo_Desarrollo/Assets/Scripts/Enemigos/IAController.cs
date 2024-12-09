using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TiposDeAtaque
{
    Melee,
    Embestida
}
public class IAController : MonoBehaviour
{
    
   [Header("Estados")]
    [SerializeField] private IAEstado estadoInicial;
    [SerializeField] private IAEstado estadoDefault;

   [Header("Config")]
    [SerializeField] private float rangoDeteccion;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private LayerMask personajeLayerMask;
    [SerializeField] private float rangoDeAtaque;


    [Header("Debug")] 
    [SerializeField] private bool mostrarDeteccion;
    [SerializeField] private bool mostrarRangoAtaque;
    [Header("Ataque")] 
    [SerializeField] private float daño;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private TiposDeAtaque tipoAtaque;

    private float tiempoParaSiguienteAtaque;

    public Transform PersonajeReferencia { get; set; }
    public IAEstado EstadoActual { get; set; }
    public EnemigoMovimiento EnemigoMovimiento { get; set; }
    public float RangoDeteccion => rangoDeteccion;
    public float RangoDeAtaque => rangoDeAtaque;

    public float Daño => daño;
    public TiposDeAtaque TipoAtaque => tipoAtaque;
    public float VelocidadMovimiento => velocidadMovimiento;
    public LayerMask PersonajeLayerMask =>personajeLayerMask;

    private void Start()
    {
        EstadoActual = estadoInicial;
        EnemigoMovimiento = GetComponent<EnemigoMovimiento>();
    }

     private void Update()
    {
        EstadoActual.EjecutarEstado(this);
    }

    public void CambiarEstado(IAEstado nuevoEstado)
    {
        if (nuevoEstado != estadoDefault)
        {
            EstadoActual = nuevoEstado;
        }
    }
     private void OnDrawGizmos()
    {
        if (mostrarDeteccion)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
        }

        
    }
   
    public bool PersonajeEnRangoDeAtaque(float rango)
    {
        float distanciaHaciaPersonaje = (PersonajeReferencia.position - transform.position).sqrMagnitude;
        if (distanciaHaciaPersonaje < Mathf.Pow(rango, 2))
        {
            return true;
        }

        return false;
    }
    
    public bool EsTiempoDeAtacar()
    {
        if (Time.time > tiempoParaSiguienteAtaque)
        {
            return true;
        }

        return false;
    }
    public void ActualizarTiempoEntreAtaques()
    {
        tiempoParaSiguienteAtaque = Time.time + tiempoEntreAtaques;
    }

}
