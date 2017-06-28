using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PController : MonoBehaviour
{
    //playerStats
    public int sensitivity = 2;
    public int speed = 5;
    public Vector3 move;

    //gameObject references
    public GameObject itemImage;
    public GameObject cam;

    //raycast references
    public int range = 10;
    private RaycastHit hit;

    //class references
    public InventoryManager iManager;

    void Start()
    {

    }

    void Update()
    {
        Rotate();
        RayShoot();
        Move();
    }

    void Rotate()
    {
            //allows player to rotate camera around.
        if (Input.GetButton("Fire2"))
        {
            transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X")), 0 * sensitivity));
            cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0 * sensitivity));
        }
    }

    void Move()
    {
            //allows movement for player
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        transform.Translate(move * Time.deltaTime * speed);
    }

    void RayShoot()
    {
        //allows player to shoot raycasts and picking up items
        if (Input.GetButtonDown("E")) {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * range, Color.red);
             if(Physics.Raycast(cam.transform.position,cam.transform.forward*range,out hit, range))
              {
                if (hit.transform.GetComponent<Item>() != null)
                {
                    Destroy(hit.transform.gameObject);
                    
                    for(int i =0; i < iManager.invSlots.Count; i++)
                    {
                        if (iManager.invSlots[i].transform.childCount == 0)
                        {
                           //when player hits an pick-able item. It's added to the inventory to the nearest avaible slot.
                            GameObject slotImage =(GameObject)Instantiate(itemImage, iManager.invSlots[i].transform.position, iManager.invSlots[i].transform.rotation);
                            slotImage.transform.parent = iManager.invSlots[i].transform;                           
                            break;
                        }
                        
                    }
                }

            }
        }
    }
}

