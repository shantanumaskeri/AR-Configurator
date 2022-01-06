using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class FeatureSelection : MonoBehaviour 
{
	public static FeatureSelection Instance;

	[Header ("Vehicle Swap")]
	public GameObject vw;
	public GameObject bmw;

	[Header ("AR Menu")]
	public GameObject arMenu;
	public GameObject markerMenu;

	[Header ("Car Parts")]
	public GameObject door1;
	public GameObject door2;
	public GameObject bonnet;
	public Text carPartLabel;

	[HideInInspector]
	public bool isMoveEnabled;
	[HideInInspector]
	public bool isRotateEnabled;
	[HideInInspector]
	public bool isXrayEnabled;

	Animation doorAnim;
	Animation bonnetAnim;

	int doorId;
	int bonnetId;

	GameObject target;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		isMoveEnabled = isXrayEnabled = false;
		isRotateEnabled = true;

		doorId = bonnetId = -1;

		target = vw;
	}

	// Update is called once per frame
	void Update () 
	{
		arMenu.SetActive (GuiConfigure.Instance.isGuiEnabled);
	}

	public void ConfigureControls (string control)
	{
		if (control.Equals ("continue"))
		{
			markerMenu.SetActive (false);

			ApplicationControl.Instance.isShowingMarkerMenu = false;
		}
		else if (control.Equals ("getmarker"))
		{
			Application.OpenURL ("http://dev.happyfinish.com/testing/ar-configurator/ferrari-marker.zip");
		}
		else if (control.Equals ("move"))
		{
			isMoveEnabled = true;
			isRotateEnabled = false;	
		}
		else if (control.Equals ("rotate"))
		{
			isRotateEnabled = true;
			isMoveEnabled = false;
		}
		else if (control.Equals ("vw"))
		{
			target = vw;
			carPartLabel.text = "Doors";

			VehicleSwap.Instance.Change3DMesh (vw, bmw);
		}
		else if (control.Equals ("bmw"))
		{
			target = bmw;
			carPartLabel.text = "Bonnet";

			VehicleSwap.Instance.Change3DMesh (bmw, vw);
		}
		else if (control.Equals ("xray"))
		{
			isXrayEnabled = !isXrayEnabled;

			VehicleXray.Instance.ChangeMeshView (isXrayEnabled);
		}
		else if (control.Equals ("camera"))
		{
			SaveScreenshot ();
		}
		else if (control.Equals ("carpart"))
		{
			switch (target.name)
			{
			case "Volkswagen Polo":
				doorId = -doorId;

				PlayVehicleAnimation (door1, doorAnim, doorId, "door", "001");
				PlayVehicleAnimation (door2, doorAnim, doorId, "door", "002");
				break;

			case "BMW X5":
				bonnetId = -bonnetId;

				PlayVehicleAnimation (bonnet, bonnetAnim, bonnetId, "bonnet", "001");
				break;
			}
		}
		else if (control.Equals ("dealership"))
		{
			switch (target.name)
			{
			case "Volkswagen Polo":
				Application.OpenURL ("http://www.volkswagen.co.in/en/shopping-tools/find_a_dealer.html");
				break;

			case "BMX X5":
				Application.OpenURL ("http://www.bmw.in/en/fastlane/dealer-locator.html");
				break;
			}
		}
		else if (control.Equals ("download"))
		{
			Application.OpenURL ("http://dev.happyfinish.com/testing/ar-configurator/ferrari-marker.zip");
		}
		else if (control.Equals ("information"))
		{
			switch (target.name)
			{
			case "Volkswagen Polo":
				Application.OpenURL ("http://www.volkswagenag.com/en/group.html");
				break;

			case "BMX X5":
				Application.OpenURL ("http://www.bmwgroup.com/en/company.html");
				break;
			}
		}
		else if (control.Equals ("newsletter"))
		{
			switch (target.name)
			{
			case "Volkswagen Polo":
				Application.OpenURL ("http://www.volkswagen.at/news-magazin/newsletter");
				break;

			case "BMX X5":
				Application.OpenURL ("http://forms.bmw.co.uk/forms/oli_bmw_newssubs");
				break;
			}
		}
		else if (control.Equals ("website"))
		{
			switch (target.name)
			{
			case "Volkswagen Polo":
				Application.OpenURL ("http://www.volkswagen.co.in/en.html");
				break;

			case "BMX X5":
				Application.OpenURL ("http://www.bmw.in/en/index.html");
				break;
			}
		}
	}

	void PlayVehicleAnimation (GameObject go, Animation anim, int id, string animPart, string animLabel)
	{
		anim = go.GetComponent<Animation>();

		if (!anim.isPlaying)
		{
			switch (id)
			{
			case 1:
				anim.CrossFade (animPart+"Open_"+animLabel);
				break;

			case -1:
				anim.CrossFade (animPart+"Close_"+animLabel);
				break;
			}
		}
	}

	void SaveScreenshot ()
	{
		RenderTexture rt = new RenderTexture(4096, 2160, 24);
		Camera.main.targetTexture = rt;
		Texture2D screenShot = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
		Camera.main.Render();
		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
		Camera.main.targetTexture = null;
		RenderTexture.active = null;

		byte[] bytes;
		bytes = screenShot.EncodeToJPG();
		string date = System.DateTime.Now.ToString("hh-mm-ss_dd-MM-yy");
		string screenshotFilename = "Screenshot" + "_" + date + ".jpg";
		string path = Application.persistentDataPath + "/" + screenshotFilename;


		#if UNITY_ANDROID && !UNITY_EDITOR
		if (Application.platform == RuntimePlatform.Android) 
		{
		string androidPath = Path.Combine("MyScreenshots", screenshotFilename);
		path = Path.Combine(Application.persistentDataPath, androidPath);
		string pathonly = Path.GetDirectoryName(path);
		Directory.CreateDirectory(pathonly);
		}
		#endif

		System.IO.File.WriteAllBytes(path, bytes);
	}
}
