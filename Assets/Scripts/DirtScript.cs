using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DirtScript : MonoBehaviour
{
    public GameObject Spray;
    public AudioClip[] WipeSounds;
    public AudioClip[] SpraySounds;

	private bool sprayed = false;
	private int wiped = 0;
	Color tmp;
	AudioSource soundPlayer;

	void Start()
	{
		soundPlayer = GetComponent<AudioSource>(); 
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.name == "SprayBottle" && !sprayed)
		{
			sprayed = true;
			Instantiate(Spray, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(Random.Range(0, 2)*180, Random.Range(0, 2)*180, 0));
			soundPlayer.PlayOneShot(SpraySounds[Random.Range(0, SpraySounds.Length)]);
		}

	}

	void OnTriggerExit2D(Collider2D other){

		tmp = this.GetComponent<SpriteRenderer>().color;

		if(other.gameObject.name == "Rag" && sprayed)
		{

			wiped++;

			tmp.a -= 0.15f;
 			this.GetComponent<SpriteRenderer>().color = tmp;

			if(wiped >= 3)
			{

				AudioSource.PlayClipAtPoint(WipeSounds[Random.Range(0, WipeSounds.Length)], Camera.main.transform.position );
				Destroy(this.gameObject);

			}
		
		}

	}

}
