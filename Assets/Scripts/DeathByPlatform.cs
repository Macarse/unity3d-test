using UnityEngine;
using System.Collections;

public class DeathByPlatform : MonoBehaviour
{
    public Player playerScript;
	
	void OnCollisionEnter(Collision collision)
    {
		Debug.Log("OnCollisionEnter!");
		if(playerScript != null)
			playerScript.NotifyDeath();
    }
}
