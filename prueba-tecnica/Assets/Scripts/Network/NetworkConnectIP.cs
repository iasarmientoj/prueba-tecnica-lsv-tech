using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

/// <summary>
/// Maneja la conexión en red mediante IP, permitiendo crear o unirse a un juego en la misma red.
/// </summary>
public class NetworkConnectIP : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private TextMeshProUGUI ipAddressText;
    [SerializeField] private TextMeshProUGUI ipAddressText1;
    [SerializeField] private TMP_InputField ipInputField;

    [SerializeField] private string ipAddressPropia;
    [SerializeField] private UnityTransport transport;

    [SerializeField] private GameObject panelConnection;
    [SerializeField] private GameObject panelStopHost;
    [SerializeField] private GameObject panelStopClient;
    [SerializeField] private GameObject panelError;

    #endregion

    #region Unity Methods

    private void Start()
    {
        ipAddressPropia = GetIpAddressPropia();
        ipAddressText.text = ipAddressPropia;
        ipAddressText1.text = ipAddressPropia;
    }

    #endregion

    #region Networking Methods

    /// <summary>
    /// Obtiene la dirección IP local de la red en la que está conectado el dispositivo.
    /// </summary>
    /// <returns>Dirección IP local en formato string.</returns>
    private string GetIpAddressPropia()
    {
        string localIP = "127.0.0.1"; // Valor predeterminado en caso de fallo

        foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().StartsWith("192."))
            {
                return ip.ToString(); // Retorna la primera IP que empieza por 192
            }
        }

        throw new System.Exception("No network adapters with an IPv4 address in the system!");
    }

    /// <summary>
    /// Inicia el juego como host, permitiendo que otros clientes se conecten.
    /// </summary>
    public void StartHost()
    {
        SetIpAddress(ipAddressPropia);
        NetworkManager.Singleton.StartHost();
        panelConnection.SetActive(false);
        panelStopHost.SetActive(true);
    }

    /// <summary>
    /// Se conecta a una sesión de juego como cliente, validando la dirección IP ingresada.
    /// </summary>
    public void StartClient()
    {
        string ipAddressHost = ipInputField.text;

        if (ValidateIP(ipAddressHost))
        {
            SetIpAddress(ipAddressHost);
            NetworkManager.Singleton.StartClient();
            panelConnection.SetActive(false);
            panelStopClient.SetActive(true);
        }
        else
        {
            ipInputField.text = "";
            panelError.SetActive(true);
        }
    }

    /// <summary>
    /// Asigna la dirección IP de conexión en Unity Transport.
    /// Solo se usa en el lado del cliente.
    /// </summary>
    /// <param name="ipAddress">Dirección IP a configurar.</param>
    public void SetIpAddress(string ipAddress)
    {
        transport.SetConnectionData(ipAddress, transport.ConnectionData.Port);
    }

    #endregion

    #region Utility Methods

    /// <summary>
    /// Valida si una dirección IP cumple con el formato "192.168.x.x",
    /// donde "x" es un número entre 0 y 255.
    /// </summary>
    /// <param name="ipAddress">La dirección IP a validar.</param>
    /// <returns>true si la IP es válida, false en caso contrario.</returns>
    private bool ValidateIP(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress)) return false;

        string pattern = @"^192\.168\.(\d{1,3})\.(\d{1,3})$";
        Match match = Regex.Match(ipAddress, pattern);

        if (!match.Success) return false;

        int octet3 = int.Parse(match.Groups[1].Value);
        int octet4 = int.Parse(match.Groups[2].Value);

        return octet3 >= 0 && octet3 <= 255 && octet4 >= 0 && octet4 <= 255;
    }

    #endregion
}
