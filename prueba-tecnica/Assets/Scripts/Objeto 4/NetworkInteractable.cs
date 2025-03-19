using System;
using Unity.Netcode;
using UnityEngine;

public class NetworkInteractable : NetworkBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Collider col;

    // Variable de red para controlar si el objeto est� siendo sostenido
    private NetworkVariable<bool> isHeld = new NetworkVariable<bool>(false, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        // Sincronizar el estado del collider al cambiar la variable de red
        isHeld.OnValueChanged += OnValueChange;
    }

    private void OnValueChange(bool wasHeld, bool _isHeld)
    {
        if (_isHeld)
        {
            Debug.Log("isHeld");
        }
        else
        {
            Debug.Log("isNotHeld");

        }

    }

    public void TryPickUp()
    {
       // if (!IsOwner) return;

        // Llamar al servidor para solicitar la posesi�n y desactivar el collider
        RequestPickUpServerRpc(NetworkManager.Singleton.LocalClientId);
    }

    public void TryDrop()
    {
       // if (!IsOwner) return;

        // Llamar al servidor para liberar el objeto
        RequestDropServerRpc();
    }

    [ServerRpc(RequireOwnership = false)] 
    private void RequestPickUpServerRpc(ulong clientId)
    {

        // Transferir la propiedad al jugador que lo tom�
        GetComponent<NetworkObject>().ChangeOwnership(clientId);
        isHeld.Value = true;
        rb.useGravity = false;
        col.enabled = false;
    }

    [ServerRpc(RequireOwnership = false)]
    private void RequestDropServerRpc()
    {
       // if (!IsOwner) return;

        isHeld.Value = false;
        col.enabled = true;
        rb.useGravity = true;
        GetComponent<NetworkObject>().RemoveOwnership();
    }
}
