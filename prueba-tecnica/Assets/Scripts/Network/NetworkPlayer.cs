using UnityEngine;
using Unity.Netcode;

/// <summary>
/// Representa un jugador en la red, sincronizando su posición y ocultando su modelo local.
/// </summary>
public class NetworkPlayer : NetworkBehaviour
{
    #region Serialized Fields

    [SerializeField] private Transform root;
    [SerializeField] private Transform head;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;

    [SerializeField] private Renderer[] meshToDisable;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Se ejecuta cuando el objeto es generado en la red.
    /// Si el jugador es el dueño del objeto, desactiva su propia malla.
    /// </summary>
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            DisableLocalMeshes();
        }
    }

    private void Update()
    {
        if (IsOwner)
        {
            SyncTransformWithVRRig();
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Desactiva las mallas del jugador local para evitar ver su propio avatar.
    /// </summary>
    private void DisableLocalMeshes()
    {
        foreach (var mesh in meshToDisable)
        {
            mesh.enabled = false;
        }
    }

    /// <summary>
    /// Sincroniza la posición y rotación del jugador con los datos del VRRigReferences.
    /// </summary>
    private void SyncTransformWithVRRig()
    {
        root.SetPositionAndRotation(VRRigReferences.Singleton.root.position, VRRigReferences.Singleton.root.rotation);
        head.SetPositionAndRotation(VRRigReferences.Singleton.head.position, VRRigReferences.Singleton.head.rotation);
        leftHand.SetPositionAndRotation(VRRigReferences.Singleton.leftHand.position, VRRigReferences.Singleton.leftHand.rotation);
        rightHand.SetPositionAndRotation(VRRigReferences.Singleton.rightHand.position, VRRigReferences.Singleton.rightHand.rotation);
    }

    #endregion
}
