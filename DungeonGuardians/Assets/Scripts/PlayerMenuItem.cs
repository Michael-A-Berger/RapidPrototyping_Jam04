using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuItem /*: MonoBehaviour/**/
{
    // Delegate
    public delegate void SelectItem();

    // Public Properties
    public string menuName = "[undefined]";
    public SelectItem select = null;
}
