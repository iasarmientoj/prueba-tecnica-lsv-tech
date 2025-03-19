using UnityEngine;

/// <summary>
/// Simula la física manualmente en cada frame utilizando Physics.Simulate.
/// </summary>
public class PhysicsSimulate : MonoBehaviour
{
    #region Unity Methods

    /// <summary>
    /// Llamado una vez por frame. Simula la física manualmente con el tiempo de FixedUpdate.
    /// </summary>
    void Update()
    {
        Physics.Simulate(Time.fixedDeltaTime);
    }

    #endregion
}
