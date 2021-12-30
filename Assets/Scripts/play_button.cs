using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play_button : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnMouseDown()
    {
        SceneManager.LoadScene("Assets/Scenes/Scene1.unity");
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            GetComponent<SpriteRenderer>().color = new Color(167f / 255f, 184f / 194f, 255f / 255f);
        }
    }
}
