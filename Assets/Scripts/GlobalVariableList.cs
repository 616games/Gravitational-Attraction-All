using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows a type to be specified for the List when inherited from this class.
/// </summary>
public abstract class GlobalVariableList<T> : ScriptableObject, ISerializationCallbackReceiver
{
    [TextArea(5, 10)]
    [Tooltip("Optional description for the purpose of this global list.")]
    [SerializeField]
    private string _description;

    /// <summary>
    /// Starting contents of the list.
    /// </summary>
    [SerializeField]
    private List<T> _initialContents = new List<T>();
    
    /// <summary>
    /// Creates a copy of the initial contents and uses this during runtime.
    /// </summary>
    private List<T> _runtimeContents = new List<T>();

    public void OnBeforeSerialize()
    {
        if (_initialContents.Count <= 0) return;
        
        for (int i = 0; i < _initialContents.Count; i++)
        {
            _runtimeContents.Add(_initialContents[i]);
        }
    }

    public void OnAfterDeserialize()
    {
    }
    
    /// <summary>
    /// Mimics the functionality of List.Count().
    /// </summary>
    public int Count { get { return _runtimeContents.Count; } }

    public void Add(T _item)
    {
        if (!_runtimeContents.Contains(_item))
        {
            _runtimeContents.Add(_item);
        }
    }

    /// <summary>
    /// Mimics the functionality of List.Clear().
    /// </summary>
    public void Clear()
    {
        if (_runtimeContents.Count > 0)
        {
            for (int i = 0; i < _runtimeContents.Count; i++)
            {
                _runtimeContents[i] = default(T);
            }
        }
    }
    
    /// <summary>
    /// Mimics the functionality of List.Contains().
    /// </summary>
    public bool Contains(T _item)
    {
        for (int i = 0; i < _runtimeContents.Count; i++)
        {
            if (_runtimeContents.Contains(_item))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Mimics the functionality of List.Remove()
    /// </summary>
    public void Remove(T _item)
    {
        if (_runtimeContents.Contains(_item))
        {
            _runtimeContents.Remove(_item);
        }
    }

    /// <summary>
    /// Mimics the functionality of calling the contents of the List by index.
    /// </summary>
    /// <param name="_index"></param>
    public T this[int _index] { get { return _runtimeContents[_index]; } }
}
