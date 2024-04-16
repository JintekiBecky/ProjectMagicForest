using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Inventory
{
	private List<S_Item> itemList;

	public S_Inventory()
	{
		itemList = new List<S_Item> ();

		AddItem(new S_Item { itemtype = S_Item.ItemType.Mushroom1, amount = 1 });
		AddItem(new S_Item { itemtype = S_Item.ItemType.Mushroom2, amount = 1 });
		AddItem(new S_Item { itemtype = S_Item.ItemType.Mushroom3, amount = 1 });
		Debug.Log(itemList.Count);
	}

	public void AddItem(S_Item item)
	{
		itemList.Add (item);
	}

	public List<S_Item> getItemList()
	{
		return itemList;
	}

}
