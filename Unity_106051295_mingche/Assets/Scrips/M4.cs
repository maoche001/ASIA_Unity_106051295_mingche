using UnityEngine;

public class M4 : MonoBehaviour
{
    public Rigidbody M4_rig;
    public float M4_speed;
    public Transform M4_tran;
    
    private void Update()
    {
        if(GameObject.Find("M4a1").GetComponent<HingeJoint>().connectedBody == null)
        {
            M4_rig.AddForce(M4_tran.forward * M4_speed * Time.deltaTime);
        }
    }
}
