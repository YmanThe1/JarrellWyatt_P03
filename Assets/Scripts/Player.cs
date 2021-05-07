using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other) //trigger pickiing up items
    {
        var item = other.GetComponent<GroundItem>();
        if(item)
        {
            inventory.AddItem(new Item (item.item), 1); //pick up object add to inventory
            Destroy(other.gameObject); //destroy object
            Debug.Log("Picked Up Object");
        }
    }

    private void Update() //update only on key press
    {
        if(Input.GetKeyDown(KeyCode.Space)) //allow saving inventory
        {
            inventory.Save();
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter)) //allow loading inventory
        {
            inventory.Load();
        }
        if (Input.GetKey("escape")) //allow player to quit application
        {
            Application.Quit();
        }
    }
    private void OnApplicationQuit()
    {
        inventory.Container.Items.Clear(); //clear inventory when application exited
    }
}
