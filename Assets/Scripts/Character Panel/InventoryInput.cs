using UnityEngine;

public class InventoryInput : MonoBehaviour
{
	[SerializeField] GameObject characterPanelGameObject;
	[SerializeField] GameObject equipmentPanelGameObject;
	[SerializeField] KeyCode[] toggleCharacterPanelKeys;
	[SerializeField] KeyCode[] toggleInventoryKeys;
	[SerializeField] bool showAndHideMouse = true;
	[SerializeField] Canvas canvas;

	void Update()
	{
		ToggleCharacterPanel();
		ToggleInventory();
	}

	private void ToggleCharacterPanel()
	{
	 if(!Starter.terminal) {
		for (int i = 0; i < toggleCharacterPanelKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleCharacterPanelKeys[i]))
			{
				characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);

				if (characterPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(true);
					canvas.sortingOrder = -1;
				}
				else
				{
					canvas.sortingOrder = 1;
					
				}

				break;
			}
		}
	  }
	}

	private void ToggleInventory()
	{
	 if(!Starter.terminal) {
		for (int i = 0; i < toggleInventoryKeys.Length; i++)
		{
			if (Input.GetKeyDown(toggleInventoryKeys[i]))
			{
				if (!characterPanelGameObject.activeSelf)
				{
					characterPanelGameObject.SetActive(true);
					equipmentPanelGameObject.SetActive(false);
				}
				else if (equipmentPanelGameObject.activeSelf)
				{
					equipmentPanelGameObject.SetActive(false);
				}
				else
				{
					characterPanelGameObject.SetActive(false);
				}
				break;
			}
		 }
	  }
	}

	public void ShowMouseCursor()
	{
		if (showAndHideMouse)
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public void HideMouseCursor()
	{
		if (showAndHideMouse)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}

	public void ToggleEquipmentPanel()
	{
		equipmentPanelGameObject.SetActive(!equipmentPanelGameObject.activeSelf);
	}
}
