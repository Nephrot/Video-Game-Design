using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
  #region Singleton
	public static InventoryManager INSTANCE;
	private void Awake() {
		INSTANCE = this;
	}
  #endregion 
  public List<ContainerGet> containers = new List<ContainerGet>();
  private Container currentOpenContainer;
  public GameObject getContainerPrefab(string name) {
	  foreach(ContainerGet container in containers) {
		  if(container.containerName == name) {
			  return container.containerPrefab;
		  }
	  }
	  return null;
  }
  public void openContainer(Container container) {
	  if(currentOpenContainer != null) {
          currentOpenContainer.closeContainer();
	  }
	  currentOpenContainer = container;
  }
  public void closeContainer() {
	  if(currentOpenContainer != null) {
          currentOpenContainer.closeContainer();
	  }
  }
}
[System.Serializable]
public class ContainerGet {
	public string containerName;
	public GameObject containerPrefab;
}