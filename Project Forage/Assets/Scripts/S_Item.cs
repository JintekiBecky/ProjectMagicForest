using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Item { 

	public enum ItemType
	{
		Mushroom1,Mushroom2, Mushroom3,
		Wood,Stone,Honey,
	}

	public ItemType itemtype;
	public int amount;

	public Sprite GetSprite()
	{
		switch (itemtype)
		{
			default:
			case ItemType.Mushroom1:	return S_ItemAssets.Instance.Mushroom1Sprite;
			case ItemType.Mushroom2:	return S_ItemAssets.Instance.Mushroom2Sprite;
			case ItemType.Mushroom3:	return S_ItemAssets.Instance.Mushroom3Sprite;
		}
	}
}
