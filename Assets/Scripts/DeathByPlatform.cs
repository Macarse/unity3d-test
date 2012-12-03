using UnityEngine;
using System.Collections;

public class DeathByPlatform : MonoBehaviour
{
    public Player playerScript;

    void OnCollisionEnter()
    {
		if(playerScript != null)
			playerScript.NotifyDeath();
    }
}
