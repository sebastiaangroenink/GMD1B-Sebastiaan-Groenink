using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int sensitivity = 2;
    public GameObject cam;
    public int speed = 5;
    public Vector3 move;
    public GameObject bomb;
    public int throwPower = 1000;
    public Transform bombSpawn;
    public float fireRate;
    public float nextFire;
    public int bombCount;
    public Vector3 dir;
    public int range = 10;
    private RaycastHit hit;
    private bool elevatorMove;
    private bool canJump;
    private int jumpForce = 500;

    void Update()
    {
        Rotate();
        Move();
        Shoot();
        BombPick();
        Jump();
    }

    void Rotate()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0 * sensitivity));
            cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0 * sensitivity));

        }
    }
    void Move()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        transform.Translate(move * Time.deltaTime * speed);
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && canJump)
        {
            transform.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
            canJump = false;
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && bombCount > 0)
        {
            nextFire = Time.time + fireRate;
            GameObject g = (GameObject)Instantiate(bomb, bombSpawn.position, bombSpawn.rotation);
            g.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwPower);
        }
    }

    void BombPick()
    {
        if (Input.GetButtonDown("E"))
        {
            
            Debug.DrawRay(cam.transform.position,cam.transform.forward * range, Color.red, 4.0f);
            if (Physics.Raycast(cam.transform.position,cam.transform.forward,out hit,range))
            {
                
                if(hit.transform.tag == "bombPick")
                {
                    Destroy(hit.transform.gameObject);
                    bombCount++;
                }
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        canJump = true;
    }
}

