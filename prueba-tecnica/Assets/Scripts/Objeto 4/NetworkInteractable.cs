using System;
using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Representa un objeto interactuable en red que puede ser recogido y soltado por los jugadores.
/// </summary>
public class NetworkInteractable : NetworkBehaviour
{
    #region Variables Privadas

    private Rigidbody rb;
    [SerializeField] private Collider col;

    /// <summary>
    /// Variable de red para controlar si el objeto está siendo sostenido.
    /// </summary>
    private NetworkVariable<bool> isHeld = new NetworkVariable<bool>(
        false,
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Server
    );

    #endregion

    #region Métodos de Unity

    /// <summary>
    /// Inicializa las referencias del componente.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Se ejecuta cuando el objeto es instanciado en la red.
    /// </summary>
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        // Sincroniza el estado del collider cuando cambia la variable de red.
        isHeld.OnValueChanged += OnValueChange;
    }

    #endregion

    #region Métodos de Control de Estado

    /// <summary>
    /// Callback llamado cuando cambia el estado de la variable de red <c>isHeld</c>.
    /// </summary>
    /// <param name="wasHeld">Valor anterior.</param>
    /// <param name="_isHeld">Nuevo valor.</param>
    private void OnValueChange(bool wasHeld, bool _isHeld)
    {
        Debug.Log(_isHeld ? "isHeld" : "isNotHeld");
        col.enabled = !_isHeld;
        rb.useGravity = !_isHeld;
    }

    /// <summary>
    /// Recoge el objeto llamando al servidor para solicitar la posesión.
    /// </summary>
    public void TryPickUp()
    {
        RequestPickUpServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    /// <summary>
    /// Suelta el objeto llamando al servidor para liberar la posesión.
    /// </summary>
    public void TryDrop()
    {
        RequestDropServerRpc();
    }

    #endregion

    #region Métodos de Servidor

    /// <summary>
    /// Solicita al servidor la posesión del objeto y desactiva su collider.
    /// </summary>
    /// <param name="clientId">ID del cliente que solicita la posesión.</param>
    [ServerRpc(RequireOwnership = false)]
    private void RequestPickUpServerRpc(ulong clientId)
    {
        GetComponent<NetworkObject>().ChangeOwnership(clientId);
        isHeld.Value = true;
        rb.useGravity = false;
        col.enabled = false;
    }

    /// <summary>
    /// Solicita al servidor liberar el objeto y restaurar su estado.
    /// </summary>
    [ServerRpc(RequireOwnership = false)]
    private void RequestDropServerRpc()
    {
        isHeld.Value = false;
        col.enabled = true;
        rb.useGravity = true;
        GetComponent<NetworkObject>().RemoveOwnership();
    }

    #endregion
}
