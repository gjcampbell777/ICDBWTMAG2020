using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    
    public GameObject Object;
    public GameObject Dirt;
    public GameObject Restart;
    public Sprite[] ObjectSprites;

    private bool clicked = false;
    private bool gameOver = false;
    private int objectsPolished = 0;
    private int timeLimit = 60;
    private float timer = 0.0f;
    private GameObject pickedUpItem;

    // Start is called before the first frame update
    void Start()
    {
        
        Setup();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                
            if (hit.collider != null)
            {

                if(hit.collider.gameObject.tag == "Restart" && gameOver)
                {

                    Restart.SetActive(false);
                    Object.SetActive(true);
                    Setup();
                    gameOver = false;
                    timer = 0.0f;
                    objectsPolished = 0;

                }

                if (hit.collider.gameObject.tag == "Item" && !clicked && !gameOver)
                {
                    pickedUpItem = hit.collider.gameObject;
                    clicked = true;
                    Cursor.visible = false;

                } else if (hit.collider.gameObject.tag == "Item" && clicked) 
                {
                    clicked = false;
                    Cursor.visible = true;

                    if(pickedUpItem.name == "Rag")
                    {
                        pickedUpItem.transform.position = new Vector2(7.25f, 2.5f);
                    } else if (pickedUpItem.name == "SprayBottle"){
                        pickedUpItem.transform.position = new Vector2(7.25f, -2.5f);
                    }

                    pickedUpItem.transform.rotation = Quaternion.identity;
                    pickedUpItem = null;
                }
             
                //Debug.Log("Clicked " + pickedUpItem.name);

            }

        }


    }


    void FixedUpdate()
    {

        timer += Time.deltaTime;
        float seconds = timeLimit - timer;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        //Debug.Log((int)seconds);

        if(clicked)
        {    
            pickedUpItem.transform.position = mousePos2D;
        }

        if(seconds < 0 && !gameOver)
        {
            //Debug.Log(objectsPolished);
            gameOver = true;

            clicked = false;
            Cursor.visible = true;

            if(pickedUpItem != null && pickedUpItem.name == "Rag")
            {
                pickedUpItem.transform.position = new Vector2(7.25f, 2.5f);
                pickedUpItem.transform.rotation = Quaternion.identity;
            } else if (pickedUpItem != null && pickedUpItem.name == "SprayBottle"){
                pickedUpItem.transform.position = new Vector2(7.25f, -2.5f);
                pickedUpItem.transform.rotation = Quaternion.identity;
            }

            Object.SetActive(false);

            //Destorys all dirt and spray gameobjects left over that player didn't clean
            GameObject[] leftovers = GameObject.FindGameObjectsWithTag("Dirt");
            foreach(GameObject residue in leftovers)
            GameObject.Destroy(residue);

            Restart.SetActive(true);
            
        }

        if (!gameOver && GameObject.FindWithTag("Dirt") == null) {
            
            objectsPolished++;
            Setup();
            //Debug.Log("GameOver");
        }

    }

    void Setup()
    {

        Object.transform.localScale = new Vector3(1, 1, 1);
        Object.GetComponent<SpriteRenderer>().sprite = null;
        Destroy(Object.GetComponent<PolygonCollider2D>());

        float sizeChange = Random.Range(0.9f, 1.25f);

        Object.GetComponent<SpriteRenderer>().sprite = 
        ObjectSprites[Random.Range(0, ObjectSprites.Length)];
        Object.transform.localRotation = Quaternion.Euler(Random.Range(0, 2)*180, Random.Range(0, 2)*180, 0);
        Object.transform.localScale *= sizeChange;

        Object.AddComponent<BoxCollider2D>();
        Object.GetComponent<BoxCollider2D>().size *= sizeChange;

        Vector3 boundary = Object.GetComponent<BoxCollider2D>().size * 0.45f;

        Destroy(Object.GetComponent<BoxCollider2D>());

        Object.AddComponent<PolygonCollider2D>();

        for(int i = 0; i < Random.Range(10, 30); i++)
        {

            float xBound = 0;
            float yBound = 0;

            RaycastHit2D placement = Physics2D.Raycast(new Vector2(xBound, yBound), Vector2.zero);

            do{

                xBound = Random.Range(-boundary.x, boundary.x);
                yBound = Random.Range(-boundary.y, boundary.y);

                placement = Physics2D.Raycast(new Vector2(xBound, yBound), Vector2.zero);

            }while(placement.collider == null || placement.collider.gameObject.tag != "Object");

            Instantiate(Dirt, new Vector2(xBound, yBound), Quaternion.Euler(Random.Range(0, 2)*180, Random.Range(0, 2)*180, 0));
        }

    }
}
