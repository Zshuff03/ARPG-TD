using UnityEngine;
using ARPGTD.CharacterStats;
using UnityEngine.AI;
using System.Collections.Generic;

public class Item {
    protected List<int> stats;

    public void Equip() {
        
    }

    public void Unequip(Inventory inv) {
        
    }

    public List<int> getStats(){
        return stats;
    }
}
