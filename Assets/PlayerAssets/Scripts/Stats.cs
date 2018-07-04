using UnityEngine;
using ARPGTD.CharacterStats;
using UnityEngine.AI;
using System.Collections.Generic;

public class Stats : MonoBehaviour {

	NavMeshAgent pc;
    public CharacterStat Strength;
    public CharacterStat Agility;
    public CharacterStat Intillect;
    public CharacterStat Stamina;

    float moveSpeed;
    
    void Start(){
        Strength.BaseValue = 10;
        Agility.BaseValue = 10;
        Intillect.BaseValue = 10;
        Stamina.BaseValue = 10;
        moveSpeed = 100;

        pc = transform.GetComponent<NavMeshAgent>();
        pc.speed = moveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
