using UnityEngine;

public class PhysicsSimulate : MonoBehaviour
{
    void Update()
    {
        Physics.Simulate(Time.fixedDeltaTime); // Simula la física manualmente
    }
}
