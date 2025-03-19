using UnityEngine;

/// <summary>
/// Activa la animaci�n de una plataforma cuando un objeto con la etiqueta "PlayerHand" entra en el trigger.
/// </summary>
public class PlataformaTrigger : MonoBehaviour
{
    #region Variables P�blicas

    /// <summary>
    /// Referencia al Animator de la plataforma.
    /// </summary>
    public Animator plataformaAnimator;

    /// <summary>
    /// Direcci�n del movimiento: 1 para derecha, -1 para izquierda.
    /// </summary>
    public int direccionMovimiento;

    #endregion

    #region M�todos de Unity

    /// <summary>
    /// Se activa cuando un objeto entra en el trigger.
    /// </summary>
    /// <param name="other">El collider del objeto que entra en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            plataformaAnimator.SetInteger("direccion", direccionMovimiento);
        }
    }

    #endregion
}
