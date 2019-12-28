using UnityEngine.SceneManagement;
using UnityEngine;

public class again : MonoBehaviour
{
    public GameObject Text;
    private void Update()
    {
        Gameover();
    }
    private void Gameover()
    {
        if(Text == true)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("第一關");
            }
        }
    }
}
