using UnityEngine;
using System.Collections;

public class ApplicationControl : MonoBehaviour 
{
	public static ApplicationControl Instance;

	[Header ("2D Setup")]
	public GameObject camera2D;
	public GameObject splashMenu;

	[Header ("AR Setup")]
	public GameObject cameraAR;
	public GameObject markerMenu;
	public GameObject arMenu;
	public GameObject brandMenu;
	public GameObject imageTarget;
	public GameObject featureSelection;

	[HideInInspector]
	public bool isShowingMarkerMenu;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		isShowingMarkerMenu = false;

		CheckDeviceModelAdjustScreens ();
		Invoke ("SwitchToARMode", 2.0f);
	}
		
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			CancelInvoke ("SwitchToARMode");

			Application.Quit ();
		}
	}

	void CheckDeviceModelAdjustScreens ()
	{
		switch (Screen.currentResolution.width)
		{
		case 1920:
			splashMenu.transform.localPosition = new Vector3 (-1280.0f, -720.0f, 0.0f);
			splashMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			splashMenu.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			markerMenu.transform.localPosition = new Vector3 (-1280.0f, -770.0f, 0.0f);
			markerMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			markerMenu.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			arMenu.transform.localPosition = new Vector3 (-960.0f, -540.0f, 0.0f);
			arMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			arMenu.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);

			brandMenu.transform.localPosition = new Vector3 (-960.0f, -540.0f, 0.0f);
			brandMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			brandMenu.transform.localScale = new Vector3 (0.75f, 0.75f, 0.75f);
			break;

		case 2560:
			splashMenu.transform.localPosition = new Vector3 (-1675.0f, -950.0f, 0.0f);
			splashMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			splashMenu.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);

			markerMenu.transform.localPosition = new Vector3 (-1640.0f, -950.0f, 0.0f);
			markerMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			markerMenu.transform.localScale = new Vector3 (1.3f, 1.3f, 1.3f);

			arMenu.transform.localPosition = new Vector3 (-1280.0f, -720.0f, 0.0f);
			arMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			arMenu.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			brandMenu.transform.localPosition = new Vector3 (-1280.0f, -720.0f, 0.0f);
			brandMenu.transform.localRotation = new Quaternion (0.0f, 0.0f, 0.0f, 1.0f);
			brandMenu.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			break;
		}
	}

	void SwitchToARMode ()
	{
		camera2D.SetActive (false);
		splashMenu.SetActive (false);

		cameraAR.SetActive (true);
		markerMenu.SetActive (true);
		imageTarget.SetActive (true);
		featureSelection.SetActive (true);

		isShowingMarkerMenu = true;
	}
}
