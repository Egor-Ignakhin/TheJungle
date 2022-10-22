using Unity.Netcode;
using UnityEngine;

public class SimpleCameraFollower : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if(IsLocalPlayer)
            Camera.main.transform.SetParent(transform);
    }
}
