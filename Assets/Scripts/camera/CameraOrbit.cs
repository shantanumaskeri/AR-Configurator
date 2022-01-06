using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour 
{
	public float distance = 10.0f;
	public float xspeed;
	public float yspeed;
	public Transform target;

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float count = Input.touchCount;

		for (int i = 0; i < count; i++)
		{
			Touch tc = Input.GetTouch (i);

			x += tc.deltaPosition.x * xspeed * 0.02f;
			y -= tc.deltaPosition.y * yspeed * 0.02f;	
			y = Mathf.Clamp (y, 0.0f, 50.0f);

			//GameObject.Find ("Debug").GetComponent<TextMesh>().text = tc.deltaPosition.y+" : "+y;
		}

		Quaternion rotation = Quaternion.Euler (y, x, 0);
		Vector3 position = rotation * (new Vector3 (0.0f, 0.0f, -distance)) + target.position;

		transform.rotation = rotation;
		transform.position = position;
	}
}
