using Unity.Netcode;
using UnityEngine;

public class SimplePlayer : NetworkBehaviour
{
    public NetworkVariable<Vector3> Position = new();

    public override void OnNetworkSpawn()
    {
    }

    [ServerRpc]
    private void SubmitInputRequestServerRpc(Vector2 input, ServerRpcParams rpcParams = default)
    {
        if (IsServer)
        {
            Position.Value += (Vector3.right * input.x + Vector3.forward * input.y) * Time.deltaTime;
            SubmitNewPositionClientRpc();
        }
    }
    
    [ClientRpc]
    private void SubmitNewPositionClientRpc()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Position.Value;
    }

    private void Update()
    {
        var input = GetInput();
        SubmitInputRequestServerRpc(input);
    }

    private Vector2 GetInput()
    {
        var vector2 = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (vector2.magnitude > 1.0f)
            vector2.Normalize();
        return vector2;
    }
}
