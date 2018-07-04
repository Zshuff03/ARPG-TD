using System.Collections;
using System.Collections.Generic;
using ARPGTD.CharacterStats;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour {

	public List<Item> inventory;

	// Use this for initialization
	void Start () {
		inventory = new List<Item>();
		for(int i=0;i<6;i++){
			inventory.Add(null);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItemToInventory(Item item){
        for(int i=0; i<6; i++){
            if(inventory[i] == null){
                inventory[i] = item;
                break;
            }
        }
        calcStats(item);
    }

    public void RemoveItemFromInventory(Item item){
        for(int i=0; i<6; i++){
            if(inventory[i] == item){
                inventory[i] = null;
                break;
            }
        }
        calcStats(item);
    }

    public Item GetItemInInventory(int itemPos){
        return inventory[itemPos];
    }

    public void calcStats(Item item){
        List<int> stats = new List<int>(); 
        for(int i=0; i<6; i++){
            if(inventory[i] != null){
                stats = inventory[i].getStats();
				Stats charStats = transform.GetComponent<Stats>();
				if(charStats.Strength.GetValue() != 0){
           			charStats.Strength.AddModifier(new StatModifier(stats[0], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Agility.GetValue() != 0){
					charStats.Agility.AddModifier(new StatModifier(stats[1], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Intillect.GetValue() != 0){
					charStats.Intillect.AddModifier(new StatModifier(stats[2], StatModType.Flat, 0, inventory[i]));
				}
				if(charStats.Stamina.GetValue() != 0){
					charStats.Stamina.AddModifier(new StatModifier(stats[3], StatModType.Flat, 0, inventory[i]));
				}
            }
			

        }
    }
}
