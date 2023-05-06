using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject pointer;

    private Vector2 mousePos;

    public InputAction shoot;
    public float shootInputValue;

    //Basic Attack Stats
    public GameObject bullet;
    public Rigidbody2D bulletRB;
    public int bulletDamage = 1;
    public int bulletSpeed = 500;
    public int spawnCount = 1;
    public float bulletSize = 1;
    public float bulletCoolDown = 0.5f;


    //public GameObject bomb;
    //public float bombSize = 10.0f;
    //public float bombCoolDown = 30.0f;


    //public GameObject shield;
    //public float shieldSize;
    //public float shieldCoolDown;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void OnEnable()
    {
        shoot.Enable();
    }
    private void OnDisable()
    {
        shoot.Disable();
    }
    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        shootInputValue = shoot.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (shootInputValue > 0)
        {
            spawnBullet();
        }
    }

    public void spawnBullet()
    {
        var dir = new Vector2(0, 0);
        var myNewBulletRB = (Rigidbody2D)Instantiate(bulletRB, transform.position, transform.rotation);
        //myNewBulletRB.velocity  = 



    }
}
