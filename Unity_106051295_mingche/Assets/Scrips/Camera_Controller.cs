using UnityEngine.SceneManagement;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Transform cam, target;
    public float speed;
    public float r_speed;

    private void Update()
    {
        float r = Input.GetAxis("Horizontal");
        cam.Rotate(0, r * r_speed * Time.deltaTime, 0);
        Vector3 pos = Vector3.Lerp(cam.position, target.position, 0.5f * speed * Time.deltaTime);
        cam.position = pos;
    }
}
