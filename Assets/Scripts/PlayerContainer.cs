using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContainer : Container {

	public PlayerContainer(Inventory containerInventory, Inventory playerInventory) : base (containerInventory, playerInventory)
	{
       
	}
	public override GameObject getContainerPrefab() {
        return InventoryManager.INSTANCE.getContainerPrefab("Player Inventory");
	}
}
