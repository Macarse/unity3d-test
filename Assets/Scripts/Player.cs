using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	private Vector3 JumpForce;
	private bool OnTheFloor;

	void Awake()
	{
		JumpForce = new Vector3(0f, 250f, 0f);
		OnTheFloor = false;
	}

	void Start()
	{
		StartCoroutine("Jump"); 
	}

	private IEnumerator Jump ()
	{
		while (true)
		{
			if (Input.GetButtonDown ("Fire1") && OnTheFloor) 
			{
				this.rigidbody.AddForce(JumpForce, ForceMode.Impulse);
				OnTheFloor = false;
				yield return new WaitForSeconds(0.2f);
				yield return StartCoroutine("DoubleJump");
			}

			yield return null;
		}
	}

	private IEnumerator DoubleJump()
	{
		bool secondJumpUsed = false;

		while ( !OnTheFloor && !secondJumpUsed ) 
		{
			if ( Input.GetButtonDown ("Fire1") )
			{
				yield return new WaitForFixedUpdate();
				this.rigidbody.velocity = Vector3.zero;
				this.rigidbody.AddForce(JumpForce, ForceMode.Impulse);
				secondJumpUsed = true;
				yield return null;
			}

			yield return null;
		}

		yield return null;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag ("Long Fall Collider"))
		{
			NotifyDeath ();
		}
		else
		{
			OnTheFloor = true;
		}
	}

	public void NotifyDeath()
	{
		Time.timeScale = 0.0f;
		Debug.Log("You just died");
	}
}
