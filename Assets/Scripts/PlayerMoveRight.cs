using UnityEngine;
using System.Collections;

public class PlayerMoveRight : MonoBehaviour 
{
	public float SpeedX;

	void LateUpdate()
	{
		this.transform.position += new Vector3(Time.deltaTime * SpeedX, 0, 0);
	}
}
