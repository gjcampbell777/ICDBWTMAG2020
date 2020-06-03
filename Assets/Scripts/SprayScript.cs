using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayScript : MonoBehaviour
{

	private int wiped = 0;
	Color tmp;

	void OnCollisionExit2D(Collision2D other){

		tmp = this.GetComponent<SpriteRenderer>().color;

		if(other.gameObject.name == "Rag")
		{
			
			wiped++;

			tmp.a -= 0.15f;
 			this.GetComponent<SpriteRenderer>().color = tmp;

			if(wiped >= 3) Destroy(this.gameObject);

		}

	}

}
