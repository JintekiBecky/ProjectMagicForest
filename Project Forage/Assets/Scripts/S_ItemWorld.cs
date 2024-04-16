using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemWorld : MonoBehaviour
{
	public static S_ItemWorld SpawnItemWorld (Vector3 position, S_Item item)
	{
		Transform transform = Instantiate(S_ItemAssets.Instance.p_ItemWorld, position, Quaternion.identity);

		S_ItemWorld itemWorld = transform.GetComponent<S_ItemWorld>();
		itemWorld.SetItem(item);

		return itemWorld;
	}

	private S_Item item;
	private SpriteRenderer spriteRenderer;

	private void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}


	public void SetItem(S_Item item)
	{
		this.item = item;
		spriteRenderer.sprite = item.GetSprite();
	}
}
