using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtScript : MonoBehaviour
{
    public GameObject Spray;

	private bool sprayed = false;

	void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.name == "SprayBottle" && !sprayed)
		{
			sprayed = true;
			Instantiate(Spray, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
		}

		if(other.gameObject.name == "Rag" && sprayed)
		{
			Destroy(this.gameObject);
		}

	}

}
