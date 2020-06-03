using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayScript : MonoBehaviour
{

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.name == "Rag")
		{
			Destroy(this.gameObject);
		}

	}

}
