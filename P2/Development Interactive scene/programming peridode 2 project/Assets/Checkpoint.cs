using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Checkpoint : MonoBehaviour {
    public int speed =50,targetIndex,editor;
    public Transform currTarget;
    public List<Transform> checkPoints = new List<Transform>();
    public GameObject checkChecker;

 
    void Start () {
        foreach(Transform child in checkChecker.transform)
        {
            checkPoints.Add(child.transform);
        }
        currTarget = checkPoints[targetIndex];
	}
	
	void Update () {
        Move();
	}
    void Move()
    {
        transform.LookAt(currTarget.position);
        var distance = Vector3.Distance(transform.position, currTarget.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(distance <= 1)
        {
            NextTarget();
        }
    }
    void NextTarget()
    {
        if(targetIndex == checkPoints.Count - 1)
        {
            editor = -1;
        }
        if(targetIndex == 0)
        {
            editor = 1;
        }
        targetIndex += editor;
        currTarget = checkPoints[targetIndex];
    }
}
