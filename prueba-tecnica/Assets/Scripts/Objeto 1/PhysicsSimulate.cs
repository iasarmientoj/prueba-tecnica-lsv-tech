using UnityEngine;

/// <summary>
/// Simula la f�sica manualmente en cada frame utilizando Physics.Simulate.
/// </summary>
public class PhysicsSimulate : MonoBehaviour
{
    #region Unity Methods

    /// <summary>
    /// Llamado una vez por frame. Simula la f�sica manualmente con el tiempo de FixedUpdate.
    /// </summary>
    void Update()
    {
        Physics.Simulate(Time.fixedDeltaTime);
    }

    #endregion
}
