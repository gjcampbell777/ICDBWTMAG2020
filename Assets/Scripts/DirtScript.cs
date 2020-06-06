using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{
    public GameObject Spray;

	private bool sprayed = false;
	private int wiped = 0;
	Color tmp;

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "SprayBottle" && !sprayed)
		{
			sprayed = true;
			Instantiate(Spray, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(Random.Range(0, 2)*180, Random.Range(0, 2)*180, 0));
		}

	}

	void OnTriggerExit2D(Collider2D other){

		tmp = this.GetComponent<SpriteRenderer>().color;

		if(other.gameObject.name == "Rag" && sprayed)
		{

			wiped++;

			tmp.a -= 0.15f;
 			this.GetComponent<SpriteRenderer>().color = tmp;

			if(wiped >= 3) Destroy(this.gameObject);
		
		}

	}

}
