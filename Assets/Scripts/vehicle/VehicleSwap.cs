using UnityEngine;
using System.Collections;

public class VehicleSwap : MonoBehaviour 
{
	public static VehicleSwap Instance;

	// Use this for initialization
	void Start () 
	{
		Instance = this;	
	}
		
	public void Change3DMesh (GameObject v1, GameObject v2)
	{
		VehicleXray.Instance.ChangeMeshView (false);

		v1.SetActive (true);
		v2.SetActive (false);
	}
}
