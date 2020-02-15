using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    // Public Properties
    public GridManager gridManager = null;
    public int playerNum = 1;
    public bool usingController = false;

    // Start()
    void Start()
    {
        // IF the grid manager is null...
        if (gridManager == null)
        {
            // Finding the grid manager
            GameObject holder = GameObject.Find("GridHolder");
            if (holder != null)
                gridManager = holder.GetComponent<GridManager>();
            else
                Debug.LogError("\"gridManager\" was not set and could not be set dynamically!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
