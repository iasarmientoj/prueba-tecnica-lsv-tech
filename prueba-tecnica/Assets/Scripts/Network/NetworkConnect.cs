using UnityEngine;
using Unity.Netcode;

/// <summary>
/// Gestiona la conexión en red, permitiendo crear o unirse a una sesión de juego.
/// </summary>
public class NetworkConnect : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Inicia el host del servidor, permitiendo que otros clientes se conecten.
    /// </summary>
    public void Create()
    {
        NetworkManager.Singleton.StartHost();
    }

    /// <summary>
    /// Inicia el cliente y se conecta a un host disponible.
    /// </summary>
    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }

    #endregion
}
