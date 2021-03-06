﻿using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;

	Inventory inventory;

	InventorySlot[] slots;
	
	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallBack += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		UpdateUI();
	}
	
	void Update () {
		
	}

	void UpdateUI() {
		for(int i = 0; i < slots.Length; i++) {
			if(i < inventory.inventory.Count && inventory.inventory[i] != null) {
				slots[i].AddItem(inventory.inventory[i]);
			} else {
				slots[i].ClearSlot();
			}
		}
	}
}
