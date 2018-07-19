using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour {

    #region Singleton
        public static Inventory instance;

        void Awake() {
            if(instance != null) {
                Debug.LogWarning("More than one instance of Inventory found!");
                return;
            }

            instance = this;
        }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

	public List<Item> inventory;
    public int inventorySlots;

	// Use this for initialization
	void Start () {
        inventorySlots = 6;
		inventory = new List<Item>();
		for(int i = 0; i < inventorySlots; i++) {
			inventory.Add(null);
		}
	}

    ///Adds an item to the inventory
	public bool Add(Item item) {
        int itemsInInventory = 0;
        for(int i=0; i<inventorySlots; i++) {
            //See if slot is empty
            if(inventory[i] == null) {
                inventory[i] = item;

                if(onItemChangedCallBack != null) {
                    onItemChangedCallBack.Invoke();
                }
                    
                return true;
            } else {
                //if slot is full
                itemsInInventory += 1;
                if(itemsInInventory >= inventorySlots) {
                    Debug.Log("Inventory is full.");
                    break;
                }
            }
        }
        itemsInInventory = 0;
        return false;
        // calcStats(item);
    }

    ///Removes an item from the inventory
    public void RemoveItemFromInventory(Item item) {
        for(int i=0; i<inventorySlots; i++) {
            if(inventory[i] == item) {
                inventory[i] = null;

                if(onItemChangedCallBack != null)
                    onItemChangedCallBack.Invoke();

                break;
            }
        }
        // calcStats(item);
    }

    ///Returns the item at a given position in the inventory
    public Item GetItemInInventory(int itemPos) {
        return inventory[itemPos];
    }

    ///Calculates and applies stats for a given item in the inventory
    public void calcStats(Item item) {
        // calculate stats
    }
}
