using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container {

	// Use this for initialization
	private GameObject spawnedContainerPrefab;
	private Inventory containerInventory;
	private Inventory playerInventory;
	public Container(Inventory containerInventory, Inventory playerInventory) {
		this.containerInventory = containerInventory;
		this.playerInventory = playerInventory;
        openContainer();
	}
	public void openContainer() {
        spawnedContainerPrefab = Object.Instantiate(getContainerPrefab(), InventoryManager.INSTANCE.transform);
	
	}
	public void closeContainer() {
         Object.Destroy(spawnedContainerPrefab);
	}

    //Needs to be overidden
	public virtual GameObject getContainerPrefab() {
		return null;
	}
	public GameObject getSpawnedContainer() {
		return spawnedContainerPrefab;
	}
	public Inventory getContainerInventory() {
		return containerInventory;
	}
	public Inventory getPlayerInventory() {
		return playerInventory;
	}
}
