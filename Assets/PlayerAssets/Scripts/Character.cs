using UnityEngine;
using ARPGTD.CharacterStats;
using UnityEngine.AI;
using System.Collections.Generic;

public class Character : MonoBehaviour {

    NavMeshAgent pc;
    public CharacterStat Strength;
    public CharacterStat Agility;
    public CharacterStat Intillect;
    public CharacterStat Stamina;

    float moveSpeed;
    public Item[] inventory;

    void Start(){
        Strength.BaseValue = 10;
        Agility.BaseValue = 10;
        Intillect.BaseValue = 10;
        Stamina.BaseValue = 10;
        moveSpeed = 100;

        inventory = new Item[] {null,null,null,null,null,null};

        pc = transform.GetComponent<NavMeshAgent>();
        pc.speed = moveSpeed;
    }

    public void AddItemToInventory(Item item){
        for(int i=0; i<6; i++){
            if(inventory[i] == null){
                inventory[i] = item;
                break;
            }
        }
        calcStats();
    }

    public void RemoveItemFromInventory(Item item){
        for(int i=0; i<6; i++){
            if(inventory[i] == item){
                inventory[i] = null;
                break;
            }
        }
        calcStats();
    }

    public Item GetItemInInventory(int itemPos){
        return inventory[itemPos];
    }

    public void calcStats(){
        List<int> stats = new List<int>(); 
        for(int i=0; i<6; i++){
            if(inventory[i] != null){
                stats = inventory[i].getStats();
            }
            //Strength.Value += stats[0];         //Need to figure out how to mix with CharacterStat

        }
    }
}
