using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;

	public override void Interact() {
		base.Interact();

		PickUp();
	}

	void PickUp() {
		if(Inventory.instance.AddItemToInventory(item)){
			Debug.Log("Picking up " + item.name);
			Destroy(gameObject);
		}
	}

}
