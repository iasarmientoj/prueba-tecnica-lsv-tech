using Unity.Netcode;
using UnityEngine;

public class NetworkSpawn : MonoBehaviour
{
    public GameObject prefab;


    public void Spawn()
    {
       GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);

        go.GetComponent<NetworkObject>().Spawn();


    }
}
