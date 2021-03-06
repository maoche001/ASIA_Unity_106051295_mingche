﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform tran;
    public float speed = 380;
    public float turn;
    public Rigidbody rig;
    public Animator ani;
    public bool catch_;
    [Header("撿東西判定")]
    public Rigidbody catch_rig;
    public bool isprop;
    public Rigidbody M4_rig;
    public float M4_speed;
    public Transform M4_tran;
    [Header("攝影機轉換")]
    public Transform cam_tran;
    public GameObject cam_obj;
    [Header("重新開始")]
    public GameObject Text;

    private void OnTriggerStay(Collider other)
    {
        print(other.name);
        if(other.name == "M4a1"&& catch_ && !isprop)
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.GetComponent<HingeJoint>().connectedBody = catch_rig;
            //other.GetComponent<BoxCollider>().enabled = false;
            //floor.SetActive(true);
            isprop = true;
        }
        
        if (other.tag == "floor" && ani.GetCurrentAnimatorStateInfo(0).IsName("catch"))
        {
            GameObject.Find("M4a1").GetComponent<HingeJoint>().connectedBody = null;
            // floor.SetActive(false);

        }
        if (other.name == "過關" && ani.GetCurrentAnimatorStateInfo(0).IsName("catch"))
        {
            GameObject.Find("M4a1").GetComponent<HingeJoint>().connectedBody = null;
            Text.SetActive(true);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "攝影機變換判定")
        {
            cam_obj.SetActive(true);
            GameObject.Find("攝影機").GetComponent<Camera_Controller>().cam = cam_tran;
        }
    }
    private void Update()
    {
        walk();
        Turn();
        Run();
        Catch();
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("catch") && isprop)
        {
            GameObject.Find("M4a1").GetComponent<HingeJoint>().connectedBody = null;
            GameObject.Find("M4a1").GetComponent<BoxCollider>().enabled = true;
            M4_rig.AddForce(M4_tran.forward*M4_speed * Time.deltaTime);
            isprop = false;
        }
    }

    private void walk()
    {
       
        float v = Input.GetAxis("Vertical");
        rig.AddForce(tran.forward * speed * v * Time.deltaTime);
        ani.SetBool("走路", v != 0);
    }
    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && ani.GetBool("走路"))
        {
            ani.SetBool("跑步", true);
            speed = 450;
        }
        else if (catch_ == true)
        {
            speed = 380;
        }
        else
        {
            ani.SetBool("跑步", false);
            speed = 380;

        }
        
    }
    private void Turn()
    {
        float h = Input.GetAxis("Horizontal");
        tran.Rotate(0, h * turn *Time.deltaTime, 0);
    }
    private void Catch()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            ani.SetTrigger("撿東西");
            ani.SetBool("idle",true);
        }
        else if(ani.GetCurrentAnimatorStateInfo(0).IsName("catch"))
        {
            catch_ = true;
            speed = 380;
        }
        else
        {
            catch_ = false;
        }
    }
}
