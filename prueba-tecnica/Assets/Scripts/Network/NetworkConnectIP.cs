using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using TMPro;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

public class NetworkConnectIP : MonoBehaviour
{

	[SerializeField] TextMeshProUGUI ipAddressText;
	[SerializeField] TextMeshProUGUI ipAddressText1;
	[SerializeField] TMP_InputField ipInputField;

	[SerializeField] string ipAddressPropia;
	[SerializeField] UnityTransport transport;

	[SerializeField] GameObject panelConnection;
	[SerializeField] GameObject panelStopHost;
	[SerializeField] GameObject panelStopClient;
	[SerializeField] GameObject panelError;

	void Start()
	{
		ipAddressPropia = GetIpAddressPropia();
		ipAddressText.text = ipAddressPropia;
		ipAddressText1.text = ipAddressPropia;
	}

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

		return localIP;

	}

	// To Host a game
	public void StartHost()
	{
		SetIpAddress(ipAddressPropia);
		NetworkManager.Singleton.StartHost();
		panelConnection.SetActive(false);
		panelStopHost.SetActive(true);
	}

	// To Join a game
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
	/// Valida si una dirección IP cumple con el formato "192.168.x.x",
	/// donde "x" es un número entre 0 y 255.
	/// </summary>
	/// <param name="ipAddress">La dirección IP a validar.</param>
	/// <returns>true si la IP es válida, false en caso contrario.</returns>
	private bool ValidateIP(string ipAddress)
	{
		// Verifica si la entrada es nula o está vacía
		if (string.IsNullOrWhiteSpace(ipAddress)) return false;

		// Expresión regular para validar el formato "192.168.x.x"
		string pattern = @"^192\.168\.(\d{1,3})\.(\d{1,3})$";
		Match match = Regex.Match(ipAddress, pattern);

		// Si no hay coincidencia, la IP no es válida
		if (!match.Success) return false;

		// Convertimos los valores capturados a enteros
		int octet3 = int.Parse(match.Groups[1].Value);
		int octet4 = int.Parse(match.Groups[2].Value);

		// Verificamos que los octetos estén dentro del rango válido (0-255)
		return octet3 >= 0 && octet3 <= 255 && octet4 >= 0 && octet4 <= 255;
	}


	/* Sets the Ip Address of the Connection Data in Unity Transport
	to the Ip Address which was input in the Input Field */
	// ONLY FOR CLIENT SIDE
	public void SetIpAddress(string ipAddress)
	{
		transport.SetConnectionData(ipAddress, transport.ConnectionData.Port);
	}



}