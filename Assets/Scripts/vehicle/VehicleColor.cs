using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VehicleColor : MonoBehaviour 
{
	GameObject target;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void ChangeMeshColor (string name)
	{
		FeatureSelection.Instance.isXrayEnabled = false;
		VehicleXray.Instance.ChangeMeshView (false);

		GameObject[] ga = GameObject.FindGameObjectsWithTag ("Car");

		foreach (GameObject g in ga) 
		{
			if (g.activeSelf)
			{
				target = g;
			}
		}

		MeshRenderer[] mra = target.GetComponentsInChildren<MeshRenderer>();

		for (int i = 0; i < mra.Length; i++)
		{
			Material[] ma = mra[i].GetComponent<MeshRenderer>().materials;

			for (int j = 0; j < ma.Length; j++)
			{
				if (ma[j].name.Equals ("body_paint (Instance)"))
				{
					switch (name)
					{
						case "blue":
						ma[j].SetColor ("_BaseColor", new Color (0.192f, 0.31f, 0.31f, 1.0f));
						break;

						case "grey":
						ma[j].SetColor ("_BaseColor", new Color (0.294f, 0.294f, 0.294f, 1.0f));
						break;

						case "brown":
						ma[j].SetColor ("_BaseColor", new Color (0.196f, 0.118f, 0.0f, 1.0f));
						break;

						case "maroon":
						ma[j].SetColor ("_BaseColor", new Color (0.698f, 0.133f, 0.133f, 1.0f));
						break;

						case "orange":
						ma[j].SetColor ("_BaseColor", new Color (1.0f, 0.271f, 0.0f, 1.0f));
						break;

						case "white":
						ma[j].SetColor ("_BaseColor", new Color (1.0f, 1.0f, 1.0f, 1.0f));
						break;

						case "green":
						ma[j].SetColor ("_BaseColor", new Color (0.0f, 0.5f, 0.0f, 1.0f));
						break;
					}
				}
			}
		}
	}
}
