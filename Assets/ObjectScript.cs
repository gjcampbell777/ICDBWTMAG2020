using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D other){

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
        }
        
        //Debug.Log("Collision");

   }
}
