using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
		// EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//un-comment once armor is done

	// void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
	// 	if(newItem ! null) {
	// 		armor.AddModifier(newItem.armorModifier);
	// 		damage.AddModifier(newitem.damageModifier);
	// 	}

	// 	if(oldItem != null) {
	// 		armor.RemoveModifier(oldItem.armorModifier);
	// 		armor.RemoveModifier(oldItem.damageModifier);
	// 	}
	// }

	//Health = 0. RIP
	public override void Die(){
		base.Die();
		PlayerManager.instance.KillPlayer();
	}

}
