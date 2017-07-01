using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //playercontrols
    public float    sensitivity = 6.0f;
    public float    speed = 5.0f;
    public Vector3  move;
    public bool     canMove = true;

    //playerstats
    public float currHP = 100.0f;
    public float maxHP  = 200.0f;
    public float currMP = 200.0f;
    public float maxMP  = 400.0f;

    //effect references
    public float mpPotionRegen   = 1.0f;
    public float mpGearRegen     = 1.5f;
    public float hpPotionRegen   = 1.0f;
    public float hpGearRegen     = 1.5f;

    //GameObject references
    public GameObject cam;
    public GameObject itemImage;

    //class references
    public Pickups               pickup;
    public PickupManager         pickManager;
    public SpellStats            spellStats;

    void Update()
    {
        if (canMove)
        {
            CamRotate();
            Move();
        }
        RegenMP();
        RegenHP();
    }

    void CamRotate()
    {
        if (Input.GetButton("Fire2"))//allows player to rotate camera
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0 * sensitivity));
            cam.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0 * sensitivity));
        }
    }

    void Move()//enables players to move with WASD keys.
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        transform.Translate(move * Time.deltaTime * speed);
    }

    void RegenMP()//regenerates players MP which allows player to use abilities.
    {
        if (currMP != maxMP)
        {
            currMP += (1 + mpPotionRegen + mpGearRegen) * Time.deltaTime;
        }
        else if(currMP>= maxMP)
        {
            currMP = maxMP;
        }
    }

    void RegenHP()//regenerates HP causing player not to permanently have damage after being hit.
    {
        if(currHP != maxHP)
        {
            currHP += 1 + hpPotionRegen + hpGearRegen * Time.deltaTime;
        }
        else if(currHP >= maxHP)
        {
            currHP = maxHP;
        }
    }
}

