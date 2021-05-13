using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    public int health;
    public float speed;
    private float dazedTime;
    public float startDatedTime;

    //public float speed;
    //public float distanceOfRay;

    //private bool movingRight = true;
    //public Transform groundDetection;

    //public Animator farmerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        //farmerAnimation.SetBool("FarmerWalk", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (dazedTime <= 0)
        {
            speed = 5;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //transform.Translate(Vector2.right * speed * Time.deltaTime);

        //RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distanceOfRay);

        //if (groundInfo.collider == false)
        //{
        //    if (movingRight == true)
        //    {
        //        transform.eulerAngles = new Vector3(0, 180, 0);
        //        movingRight = false;
        //    }
        //    else
        //    {
        //        void OnCollisionEnter(Collision col)
        //        {
        //            if (col.gameObject.name == "Duck")
        //            {
        //                transform.eulerAngles = new Vector3(0, 0, 0);
        //                movingRight = true;
        //            }
        //        }
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //        movingRight = true;
        //    }
        //}
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
