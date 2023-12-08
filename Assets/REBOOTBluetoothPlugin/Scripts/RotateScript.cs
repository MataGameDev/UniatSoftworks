using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour 
{
	public bool x;
	public bool y;
	public bool z;
	public float speed;
	
	void Update () 
	{
		if(x)
		{
			transform.Rotate (Vector3.right * speed);
		}

		else if(y)
		{
			transform.Rotate (Vector3.up * speed);
		}

		else if(z)
		{
			transform.Rotate (Vector3.forward * speed);
		}
	}
}
