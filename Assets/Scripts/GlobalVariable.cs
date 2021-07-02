using UnityEngine;

/// <summary>
/// By declaring type T, inheritors of this class can determine what type they want to be.
/// </summary>
public class GlobalVariable<T> : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// Declared initial value of the type of variable specified by the inheriting class.
    /// </summary>
    [SerializeField]
    private T _value;
    public T value { get { return _runtimeValue; } set { _runtimeValue = value; } }

    /// <summary>
    /// Get/Set the _runtimeValue and not the declared _value so _value is never overwritten.
    /// </summary>
    private T _runtimeValue;

    /// <summary>
    /// Take the declared _value and use the _runtimeValue when the game is running.
    /// </summary>
    public void OnBeforeSerialize()
    {
        _runtimeValue = _value;
    }

    public void OnAfterDeserialize()
    {
    }
}
