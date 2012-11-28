using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{	
	public PlayerMoveRight player;
	private float diff;
	
	void OnEnable()
	{
		diff = this.transform.position.x - player.transform.position.x;
	}
	
	void LateUpdate()
	{
		Vector3 goalPosition = new Vector3(player.transform.position.x + diff, transform.position.y, transform.position.z);
		goalPosition = Vector3.Lerp (transform.position, goalPosition, 1.0f);
		this.transform.position = goalPosition;
	}
}
