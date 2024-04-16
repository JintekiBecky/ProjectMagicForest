using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_UI_Inventory : MonoBehaviour
{
	private S_Inventory inventory;
	private Transform itemSlotContainer;
	private Transform itemSlotTemplate;

	private void Awake()
	{
		itemSlotContainer = transform.Find("itemSlotContainer");
		itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
	}

	public void SetInventory(S_Inventory inventory)
	{
		this.inventory = inventory;
		RefreshInventoryItems();
	}
	private void RefreshInventoryItems()
	{
		int x = 0;
		int y = 0;
		float itemSlotCellSize = 100f;

		foreach (S_Item item in inventory.getItemList()) 
		{

			RectTransform itemslotRectTransform = Instantiate(itemSlotTemplate,itemSlotContainer).GetComponent<RectTransform>();
			itemslotRectTransform.gameObject.SetActive(true);
			itemslotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
			Image image = 	itemslotRectTransform.Find("image").GetComponent<Image>();
			image.sprite = item.GetSprite();
			x++;
			if (x > 4)
			{
				x = 0;
				y++;
			}
		}
	}
}
