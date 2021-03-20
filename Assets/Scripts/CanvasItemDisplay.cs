using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasItemDisplay : MonoBehaviour
{

    [SerializeField] TMPro.TextMeshProUGUI ItemNameTextField;
    [SerializeField] GameObject MenuPannel;
    [SerializeField] GameObject InventoryPannel;
    // Start is called before the first frame update
    void Start()
    {
        MenuPannel.SetActive(false);
        InventoryPannel.SetActive(false);
    }


    public void setItemName(string ItemName)
    {
        string name = ItemName + " (Press E to pick up)";
        ItemNameTextField.SetText(name);
    }

    public void ToggleMenu()
    {
        if(MenuPannel.activeSelf)
        {
            MenuPannel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
        else
        {
            MenuPannel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

        }
    }
    public void ToggleInventory()
    {
        if (InventoryPannel.activeSelf)
        {
            InventoryPannel.SetActive(false);
        }
        else
        {
            InventoryPannel.SetActive(true);
        }
    }
}
