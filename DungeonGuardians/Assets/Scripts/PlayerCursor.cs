using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    // Public Properties
    public GridManager gridManager = null;
    [Range(1,2)]
    public int playerNum = 1;

    // Private Properties
    private GameObject cursor = null;
    private GridTile currentTile = null;
    private TextMeshPro menuText = null;
    private SpriteRenderer menuBackground = null;
    private PlayerMenuItem[] menuItems = new PlayerMenuItem[4];
    private bool inMenu = false;
    private float previousX = 0.0f;
    private float previousY = 0.0f;
    private float previousA = 0.0f;
    private float previousB = 0.0f;
    private float previousC = 0.0f;
    private float previousD = 0.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float currentA = 0.0f;
    private float currentB = 0.0f;
    private float currentC = 0.0f;
    private float currentD = 0.0f;

    // Start()
    void Start()
    {
        // IF the grid manager is null, complain about it
        if (gridManager == null)
        {
            Debug.LogError("\"gridManager\" was not set!");
        }

        // Getting the child game object + components
        cursor = transform.Find("Cursor").gameObject;
        menuText = cursor.GetComponentInChildren<TextMeshPro>();
        menuBackground = cursor.GetComponentInChildren<SpriteRenderer>();

        // Hiding the menu
        HideMenu();

        // Creating the starting menu
        CreateStartMenu();

        // Starting the wait coroutine so that the GridManager can create the grid
        StartCoroutine(WaitToStart());
    }

    // CreateStartMenu
    private void CreateStartMenu()
    {
        // Creating the menu items
        PlayerMenuItem[] newItems = new PlayerMenuItem[4];
        newItems[0] = new PlayerMenuItem {
            menuName = "Towers",
            select = Menu_PlaceTowers
        };
        newItems[1] = new PlayerMenuItem {
            menuName = "Buff",
            select = Menu_BuffTowers
        };
        newItems[2] = new PlayerMenuItem {
            menuName = "Debuff",
            select = Menu_DebuffTowers
        };
        newItems[3] = new PlayerMenuItem {
            menuName = "Exit",
            select = Menu_Exit
        };

        // Updating the menu text
        UpdateMenu(newItems);
    }

    // WaitToStart()
    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(0.01f);
        SetCursorStart();
    }

    // SetCursorStart()
    public void SetCursorStart()
    {
        Vector2Int gridSize = gridManager.GetGridSize();
        switch (playerNum)
        {
            case 1:
                PlaceCursorAtPos(0, 0);
                break;
            case 2:
                PlaceCursorAtPos(gridSize.x - 1, 0);
                break;
            case 3:
                PlaceCursorAtPos(0, gridSize.y - 1);
                break;
            case 4:
                PlaceCursorAtPos(gridSize.x - 1, gridSize.y - 1);
                break;
            default:
                Debug.LogError("Case for Player "+playerNum+" in SetCursorStart() is not defined!");
                break;
        }
    }

    // PlaceCursorAtPos()
    public void PlaceCursorAtPos(int x, int y)
    {
        GridTile tileScript = gridManager.GetGridTileAtPos(x, y);
        if (tileScript != null)
        {
            currentTile = tileScript;
            cursor.transform.position = currentTile.gameObject.transform.position;
            cursor.transform.Translate(0.0f, 0.0f, -1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the current inputs
        UpdateCurrentInputs();

        // IF the player is in the menu...
        if (inMenu)
        {
            if (currentA != previousA && currentA > 0)
                menuItems[0].select();
            if (currentB != previousB && currentB > 0)
                menuItems[1].select();
            if (currentC != previousC && currentC > 0)
                menuItems[2].select();
            if (currentD != previousD && currentD > 0)
                menuItems[3].select();
        }
        // ELSE... (the player is not in the menu)
        else
        {
            // IF the player wants to enter the menu, let them
            if (currentA != previousA && currentA > 0)
            {
                inMenu = true;
                ShowMenu();
            }

            // Moving the cursor
            bool moveX = (currentX != previousX) && (currentX != 0);
            bool moveY = (currentY != previousY) && (currentY != 0);
            if (!inMenu && (moveX || moveY))
                PlaceCursorAtPos(currentTile.gridPos.x + (int)currentX, currentTile.gridPos.y + (int)(currentY * -1f));
        }

        // Updating the previous inputs
        UpdatePreviousInputs();
    }

    // UpdateCurrent()
    private void UpdateCurrentInputs()
    {
        currentX = Input.GetAxisRaw("X_Player" + playerNum);
        currentY = Input.GetAxisRaw("Y_Player" + playerNum);
        currentA = Input.GetAxisRaw("A_Player" + playerNum);
        currentB = Input.GetAxisRaw("B_Player" + playerNum);
        currentC = Input.GetAxisRaw("C_Player" + playerNum);
        currentD = Input.GetAxisRaw("D_Player" + playerNum);
    }

    // UpdatePrevious()
    private void UpdatePreviousInputs()
    {
        previousX = currentX;
        previousY = currentY;
        previousA = currentA;
        previousB = currentB;
        previousC = currentC;
        previousD = currentD;
    }

    // ShowMenu()
    public void ShowMenu()
    {
        menuText.gameObject.SetActive(true);
        menuBackground.gameObject.SetActive(true);
    }

    // HideMenu()
    public void HideMenu()
    {
        menuText.gameObject.SetActive(false);
        menuBackground.gameObject.SetActive(false);
    }

    // UpdateMenu()
    public void UpdateMenu(PlayerMenuItem[] newMenu)
    {
        if (newMenu.Length > 4 && newMenu.Length < 1)
            Debug.LogError("Incorrect amount of menu options was passed in UpdateMenu() method! (Length: " + newMenu.Length + ")");

        for (int num = 0; num < menuItems.Length; num++)
            menuItems[num] = null;

        for (int num = 0; num < newMenu.Length && num < 4; num++)
            menuItems[num] = newMenu[num];

        // Clearing the options text
        menuText.text = "";
        for (int num = 0; num < menuItems.Length; num++)
            if (menuItems[num] != null)
                menuText.text += "(" + (char)(65 + num) + ") " + menuItems[num].menuName + "\n";
    }

    #region Menu Options
    private void Menu_PlaceTowers()
    {
        Debug.Log("Menu - Place Towers entered!");
        PlayerMenuItem[] newItems = new PlayerMenuItem[3];
        newItems[0] = new PlayerMenuItem {
            menuName = "Tower1",
            select = Submenu_Tower1
        };
        newItems[1] = new PlayerMenuItem {
            menuName = "Tower2",
            select = Submenu_Tower2
        };
        newItems[2] = new PlayerMenuItem {
            menuName = "Back",
            select = Submenu_Back
        };
        UpdateMenu(newItems);
    }

    private void Menu_BuffTowers()
    {
        Debug.Log("Menu - Buff Towers entered!");
    }

    private void Menu_DebuffTowers()
    {
        Debug.Log("Menu - Debuff Towers entered!");
    }

    private void Menu_Exit()
    {
        Debug.Log("Menu - Exit entered!");
        HideMenu();
        inMenu = false;
    }

    private void Submenu_Tower1()
    {
        Debug.Log("Submenu - Tower 1 entered!");
    }

    private void Submenu_Tower2()
    {
        Debug.Log("Submenu - Tower 2 entered!");
    }

    private void Submenu_Back()
    {
        Debug.Log("Submenu - Back entered!");
        CreateStartMenu();
    }
    #endregion
}
