using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseGoal : MonoBehaviour
{
    public string nextScene;
    public int requiredPresents;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Santa santa = collision.gameObject.GetComponent<Santa>();
        if (santa != null)
        {
            int playerPresents = santa.GetPresents();
            if (playerPresents == this.requiredPresents)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
}
