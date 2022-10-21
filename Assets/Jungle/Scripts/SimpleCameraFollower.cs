using UnityEngine;

public class SimpleCameraFollower : MonoBehaviour
{
    private void Awake()
    {
        Camera.main.transform.SetParent(transform);
    }
}
