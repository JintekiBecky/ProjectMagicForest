using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraTransition : MonoBehaviour
{
    public Vector3 cameraMoveTo;
    public Camera cam;
    public bool shouldTurnOnObj;
    public GameObject objToTurnOn;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        cam.transform.position = cameraMoveTo;		
		transiton();
	}
	private void transiton()
	{
		if (shouldTurnOnObj)
		{
			objToTurnOn.SetActive(true);
		}
		else
		{
			objToTurnOn = null;
		}
	}
}
