using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject Object;
    public GameObject Dirt;
    public Sprite[] ObjectSprites;

    private bool clicked = false;
    private GameObject pickedUpItem;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;

        Object.GetComponent<SpriteRenderer>().sprite = 
        ObjectSprites[Random.Range(0, ObjectSprites.Length)];
        Object.AddComponent<BoxCollider2D>();

        Vector3 boundary = Object.GetComponent<BoxCollider2D>().size * 0.4f;

        for(int i = 0; i < 20; i++)
        {
            float xBound = Random.Range(-boundary.x, boundary.x);
            float yBound = Random.Range(-boundary.y, boundary.y);

            Instantiate(Dirt, new Vector2(xBound, yBound), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    	Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        if (Input.GetMouseButtonDown(0))
        {

		    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Item" && !clicked)
                {
                    pickedUpItem = hit.collider.gameObject;
                    clicked = true;
                    Cursor.visible = false;

                } else if (hit.collider.gameObject.tag == "Item" && clicked) 
                {
                    clicked = false;
                    Cursor.visible = true;
                }
             
                //Debug.Log("Clicked " + pickedUpItem.name);

            }

        }

        if(clicked)
        {
            
            pickedUpItem.transform.position = mousePos2D;
        }

    }
}
