using UnityEngine;

public class PlataformaTrigger : MonoBehaviour
{
    public Animator plataformaAnimator;
    public int direccionMovimiento; // 1 para derecha, -1 para izquierda

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            plataformaAnimator.SetInteger("direccion", direccionMovimiento);
        }
    }
}
