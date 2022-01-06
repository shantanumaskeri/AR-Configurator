using UnityEngine;
using System.Collections;
using Vuforia;

public class GuiConfigure : MonoBehaviour, ITrackableEventHandler 
{
	public static GuiConfigure Instance;

	[HideInInspector]
	public bool isGuiEnabled;

	TrackableBehaviour mTrackableBehaviour;

	// Use this for initialization
	void Start () 
	{
		Instance = this;

		isGuiEnabled = false;

		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		
		if (mTrackableBehaviour) 
		{
			mTrackableBehaviour.RegisterTrackableEventHandler (this);
		}
	}
	
	public void OnTrackableStateChanged (TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED || newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			if (!ApplicationControl.Instance.isShowingMarkerMenu)
			{
				isGuiEnabled = true;	
			}
		}
		else
		{
			isGuiEnabled = false;
		}
	}
}
