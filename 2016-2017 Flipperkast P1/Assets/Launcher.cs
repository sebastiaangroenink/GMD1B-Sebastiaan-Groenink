using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    float launch = 0f;

    Animator anim;
    int shoot = Animator.StringToHash("min");
    int noShoot = Animator.StringToHash("max");

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Jump")){
            launch = 1.0F;
        }
        else { launch = 0F;
        }
        float min = Input.GetAxis("Vertical");
        anim.SetFloat("shoot", launch);
    }
}