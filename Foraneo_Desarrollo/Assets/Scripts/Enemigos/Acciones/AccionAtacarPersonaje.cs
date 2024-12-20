using UnityEngine;

[CreateAssetMenu(menuName = "Enemigos/Acciones/Atacar Personaje")]
public class AccionAtacarPersonaje : IAAccion
{
    public override void Ejecutar(IAController controller)
    {
        Atacar(controller);
    }

    private void Atacar(IAController controller)
    {
        if (controller.PersonajeReferencia == null)
        {
            return;
        }

        if (controller.EsTiempoDeAtacar() == false)
        {
            return;
        }

        if (controller.PersonajeEnRangoDeAtaque(controller.RangoDeAtaque))
        {
            
                //controller.AtaqueMelee(controller.Daño);
            
            
            controller.ActualizarTiempoEntreAtaques();
        }
    }
}
