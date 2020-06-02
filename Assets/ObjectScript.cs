using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

	/*public GameObject Dirt;
	public GameObject Spray;

	void Start(){

		this.gameObject.AddComponent<BoxCollider2D>();
		Vector3 boundary = this.GetComponent<BoxCollider2D>().size;

		for(int i = 0; i < 20; i++)
		{
			float xBound = Random.Range(-boundary.x, boundary.x);
			float yBound = Random.Range(-boundary.y, boundary.y);

			Instantiate(Dirt, new Vector2(xBound, yBound), Quaternion.identity);
		}

	}*/

    void OnCollisionStay2D(Collision2D other){
   		/*Texture2D dirt = this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite.texture;
   		Texture2D spray = this.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite.texture;

   		if(!this.transform.GetChild(1).gameObject.activeInHierarchy && 
   			other.gameObject.name == "SprayBottle") 
   		{
   			this.transform.GetChild(1).gameObject.SetActive(true);
   		}

        if(this.transform.GetChild(1).gameObject.activeInHierarchy &&
        	other.gameObject.name == "Rag") 
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);

            //Debug.Log((int)other.transform.position.x + ", " + (int)other.transform.position.y);

        }*/
        
        //Debug.Log("Collision");

    }
}
