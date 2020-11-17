using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator animator;
    private Rigidbody playerRigidbody;
    private float camRayLength = 100f;
    private int floorMask;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }
    void Animating(float h, float v)
    {
        //當h或v不為0時定義為walking
        bool walking = h != 0 || v != 0;
        animator.SetBool("iswalk",walking);

    }
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;
        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newrotation = Quaternion.LookRotation(playerToMouse);

            playerRigidbody.MoveRotation(newrotation);
        }
    }
    void Move(float h,float v)
    {
        movement.Set(h, 0f,v);
        //normalized為位置上的標準化,穩定每禎速度
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //注意GetAxis與GetAxisRaw不同，沒有Raw的情況較為緩衝
        //+Raw會變成0與1的判定沒有漸進效果
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Move(h,v);
        Turning();
        Animating(h, v);
    }
}
