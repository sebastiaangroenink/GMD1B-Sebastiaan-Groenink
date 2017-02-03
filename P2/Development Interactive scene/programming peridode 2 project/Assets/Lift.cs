using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Lift : MonoBehaviour
{
    public List<Transform> floors = new List<Transform>();
    public Transform target;
    public int floor;
    public GameObject floorGrab;

    void Start()
    {
        foreach (Transform child in floorGrab.transform)
        {
            floors.Add(child.transform);
        }
        target = floors[0];
    }

    void Update()
    {
        target = floors[floor];
        MoveLift();
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Q"))
            {
                if(floor <=2)
                floor++;
            }
            else if (Input.GetButtonDown("E"))
            {
                if(floor >= 1)
                floor--;
            }
        }
    }
    void MoveLift()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
    }
}