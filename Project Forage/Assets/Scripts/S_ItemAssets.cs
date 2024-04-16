using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemAssets : MonoBehaviour
{
	public static S_ItemAssets Instance {  get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public Transform p_ItemWorld;

	public Sprite Mushroom1Sprite;
	public Sprite Mushroom2Sprite;
	public Sprite Mushroom3Sprite;
}
