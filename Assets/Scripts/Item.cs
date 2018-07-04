using UnityEngine;
using ARPGTD.CharacterStats;
using UnityEngine.AI;
using System.Collections.Generic;

public class Item {
    protected List<int> stats;

    public void Equip() {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Inventory>().AddItemToInventory(this);
    }

    public void Unequip(Inventory inv) {
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.GetComponent<Inventory>().RemoveItemFromInventory(this);
    }

    public List<int> getStats(){
        return stats;
    }
}
