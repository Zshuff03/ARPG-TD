using UnityEngine;
using ARPGTD.CharacterStats;
using UnityEngine.AI;
using System.Collections.Generic;

public class Stats : MonoBehaviour {

	NavMeshAgent character;
    public CharacterStat Strength;
    public CharacterStat Agility;
    public CharacterStat Intellect;
    public CharacterStat Stamina;

    float moveSpeed;
    
    void Start() {
        Strength.BaseValue = 10;
        Agility.BaseValue = 10;
        Intellect.BaseValue = 10;
        Stamina.BaseValue = 10;
        moveSpeed = 100;

        character = transform.GetComponent<NavMeshAgent>();
        character.speed = moveSpeed;
    }
}
