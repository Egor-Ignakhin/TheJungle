using Unity.Netcode;
using UnityEngine;

public class CaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject caneGm;
    private void Awake()
    {
        for (int i = -100; i < 100; i += 4)
        {
            for (int j = -100; j < 100; j+= 4)
            {
                var position = new Vector3(i, 16.55056f,j);
                var instantiate = Instantiate(caneGm, transform);
                instantiate.transform.position = position;
            }
        }
    }
}
