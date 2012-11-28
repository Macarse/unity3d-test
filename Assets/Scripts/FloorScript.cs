using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour
{

	public GameObject[] NextBackgroundPrefab;
	public GameObject CurrentBackground;
	public GameObject LastBackground;
	public Transform PlayerTransform;
	
	private int CurrentIndex = 0;

	void LateUpdate ()
	{
		if (PlayerTransform.position.x > CurrentBackground.transform.position.x)
		{
			GameObject next = Instantiate(NextBackgroundPrefab[++CurrentIndex % NextBackgroundPrefab.Length]) as GameObject;
			next.transform.position = new Vector3(CurrentBackground.transform.position.x + 50f,
                                       CurrentBackground.transform.position.y,
                                       CurrentBackground.transform.position.z);
			next.transform.parent = this.transform;

			Destroy(LastBackground);
			LastBackground = CurrentBackground;
			CurrentBackground = next;
		}
	}
}
