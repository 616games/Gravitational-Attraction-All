using UnityEngine;

/// <summary>
/// Declaring as type object allows for more flexibility and you can simply typecast the contents as needed.
/// </summary>
[CreateAssetMenu(menuName = "Scriptable Object/Global Variables/List")]
public class GlobalList : GlobalVariableList<object>
{
}
