using UnityEngine;
using System.Collections;

public class VehicleXray : MonoBehaviour 
{
	public static VehicleXray Instance;

	[Header ("X-Ray")]
	public GameObject vw_xray;
	public GameObject bmw_xray;

	[Header ("Default")]
	public GameObject vw_def;
	public GameObject bmw_def;

	GameObject target;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
	}

	public void ChangeMeshView (bool xrayView)
	{
		GameObject[] ga = GameObject.FindGameObjectsWithTag ("Car");

		foreach (GameObject g in ga) 
		{
			if (g.activeSelf)
			{
				target = g;

				switch (target.name)
				{
				case "Volkswagen Polo":
					if (xrayView)
					{
						vw_xray.SetActive (true);
						vw_def.SetActive (false);
					}
					else
					{
						vw_xray.SetActive (false);
						vw_def.SetActive (true);
					}
					break;

				case "BMW X5":
					if (xrayView)
					{
						bmw_xray.SetActive (true);
						bmw_def.SetActive (false);
					}
					else
					{
						bmw_xray.SetActive (false);
						bmw_def.SetActive (true);
					}
					break;
				}
			}
		}
	}
}
