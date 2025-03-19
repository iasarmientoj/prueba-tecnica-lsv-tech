using UnityEngine;

public class VRRigReferences : MonoBehaviour
{
    #region Singleton

    /// <summary>
    /// Instancia única del VRRigReferences accesible globalmente.
    /// </summary>
    public static VRRigReferences Singleton { get; private set; }

    #endregion

    #region Referencias del Rig

    [Header("Referencias del Rig de VR")]
    [Tooltip("Transform raíz del rig de VR.")]
    public Transform root;

    [Tooltip("Transform de la cabeza del rig de VR.")]
    public Transform head;

    [Tooltip("Transform de la mano izquierda del rig de VR.")]
    public Transform leftHand;

    [Tooltip("Transform de la mano derecha del rig de VR.")]
    public Transform rightHand;

    #endregion

    private void Awake()
    {
        Singleton = this;
    }

}
