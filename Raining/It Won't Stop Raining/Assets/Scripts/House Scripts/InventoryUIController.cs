using UnityEngine;
using System.Collections;

public class InventoryUIController : MonoBehaviour {

	public GameObject[] itemIcons;

	public void ActivateIcon(InteractableController.ActivateType type) {
		itemIcons[(int)type - InteractableController.ITEM_START].SetActive(true);
	}

	public void DeactivateIcon(InteractableController.ActivateType type) {
		itemIcons[(int)type - InteractableController.ITEM_START].SetActive(false);
	}

	public void DeactivateItem(InteractableController.ActivateType type) {
		itemIcons[(int)type - InteractableController.ITEM_START].GetComponent<ItemTracker>().interactableObject.SetActive(false);
	}
}
