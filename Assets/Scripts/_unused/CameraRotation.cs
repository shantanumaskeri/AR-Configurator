using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour 
{
	public GameObject target;
	public float rotateSpeed = 5.0f;

	Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		offset = target.transform.position - transform.position;

		CalculateRotation (0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount.Equals (1))
		{
			CalculateRotation (Input.GetTouch (0).deltaPosition.x * rotateSpeed, Input.GetTouch (0).deltaPosition.y * rotateSpeed);
		}

		CalculateRotation (Input.GetAxis ("Mouse X") * rotateSpeed, Input.GetAxis ("Mouse Y") * rotateSpeed);
	}

	void CalculateRotation (float h, float v)
	{
		float horizontal = h;
		float vertical = v;

		target.transform.Rotate (vertical, horizontal, 0);

		float desiredAngle_X = target.transform.eulerAngles.x;
		float desiredAngle_Y = target.transform.eulerAngles.y;

		Quaternion rotation = Quaternion.Euler (desiredAngle_X, desiredAngle_Y, 0);
		transform.position = target.transform.position - (rotation * offset);

		transform.LookAt (target.transform);
	}
}
