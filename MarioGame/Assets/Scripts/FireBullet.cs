﻿using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    public int RateOfFire;

    public bool ReverseShootDirectionOnX;

    public bool ShootDirectionOnZ;

    private bool canShoot;

    // Use this for initialization
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(
                                           Bullet,
                                           Bullet_Emitter.transform.position,
                                           Bullet_Emitter.transform.rotation) as GameObject;

            //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            //Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 

            if (ShootDirectionOnZ)
            {
                Temporary_RigidBody.AddForce(new Vector3(0, 0, -1) * Bullet_Forward_Force);
            }
            else
            {
                if (ReverseShootDirectionOnX)
                {
                    Temporary_RigidBody.AddForce(new Vector3(1, 0, 0) * Bullet_Forward_Force);
                }
                else
                {
                    Temporary_RigidBody.AddForce(new Vector3(-1, 0, 0) * Bullet_Forward_Force);
                }
            }

            //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
            //Destroy(Temporary_Bullet_Handler, 10.0f);

            canShoot = false;

            Invoke("ShootAgain", RateOfFire);
        }
    }

    void ShootAgain()
    {
        canShoot = true;
    }
}