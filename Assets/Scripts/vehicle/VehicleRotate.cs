using UnityEngine;
using System.Collections;

public class VehicleRotate : MonoBehaviour 
{
	float xAngle;
	float yAngle;
	float xAngTemp;
	float yAngTemp;

	Vector3 firstpoint;
	Vector3 secondpoint;

	// Use this for initialization
	void Start () 
	{
		xAngle = yAngle = xAngTemp = yAngTemp = 0.0f;

		transform.rotation = Quaternion.Euler (yAngle, xAngle, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (FeatureSelection.Instance != null)
		{
			if (FeatureSelection.Instance.isRotateEnabled)
			{
				if (Input.touchCount.Equals (1))
				{
					if (Input.GetTouch (0).phase.Equals (TouchPhase.Began))
					{
						firstpoint = Input.GetTouch (0).position;

						xAngTemp = xAngle;
						yAngTemp = yAngle;
					}

					if (Input.GetTouch (0).phase.Equals (TouchPhase.Moved)) 
					{
						secondpoint = Input.GetTouch (0).position;

						xAngle = xAngTemp + (secondpoint.x - firstpoint.x) * 180.0f / Screen.width;
						yAngle = yAngTemp - (secondpoint.y - firstpoint.y) *90.0f / Screen.height;

						transform.rotation = Quaternion.Euler (0.0f, -xAngle * 2.0f, 0.0f);
					}
				}
			}	
		}
	}
}
