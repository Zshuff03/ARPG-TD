using System.Collections;
using System.Collections.Generic;
using ARPGTD.CharacterStats;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour {

	public List<Item> inventory;
    public int inventorySlots;

	// Use this for initialization
	void Start () {
        inventorySlots = 6;
		inventory = new List<Item>();
		for(int i=0;i<inventorySlots;i++) {
			inventory.Add(null);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    ///Adds an item to the inventory
	public void AddItemToInventory(Item item) {
        for(int i=0; i<inventorySlots; i++) {
            if(inventory[i] == null) {
                inventory[i] = item;
                break;
            }
        }
        calcStats(item);
    }

    ///Removes an item from the inventory
    public void RemoveItemFromInventory(Item item) {
        for(int i=0; i<inventorySlots; i++) {
            if(inventory[i] == item) {
                inventory[i] = null;
                break;
            }
        }
        calcStats(item);
    }

    ///Returns the item at a given position in the inventory
    public Item GetItemInInventory(int itemPos) {
        return inventory[itemPos];
    }

    ///Calculates and applies stats for a given item in the inventory
    public void calcStats(Item item) {
        List<int> stats = new List<int>(); 
        for(int i=0; i<inventorySlots; i++) {
            if(inventory[i] != null){
                stats = inventory[i].getStats();
                Stats charStats = transform.GetComponent<Stats>();
				if(charStats.Strength.GetValue() != 0) {
           			charStats.Strength.AddModifier(new StatModifier(stats[0], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Agility.GetValue() != 0) {
					charStats.Agility.AddModifier(new StatModifier(stats[1], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Intellect.GetValue() != 0) {
					charStats.Intellect.AddModifier(new StatModifier(stats[2], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Stamina.GetValue() != 0) {
					charStats.Stamina.AddModifier(new StatModifier(stats[3], StatModType.Flat, 0, inventory[i]));
				}
            }
			

        }
    }
}
