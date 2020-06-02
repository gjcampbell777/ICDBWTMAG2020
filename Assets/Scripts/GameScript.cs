using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject Object;

    private bool clicked = false;
    private GameObject pickedUpItem;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
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
             
                Debug.Log("Clicked " + pickedUpItem.name);

            }

        }

        if(clicked)
        {
            
            pickedUpItem.transform.position = mousePos2D;
        }

    }
}
