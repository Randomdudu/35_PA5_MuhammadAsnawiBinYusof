using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private float score = 0;
    Rigidbody RB;
    public Text Score;
    private float level;
    void Start()
    {
        RB = GetComponent<Rigidbody>();

        Scene currentscene = SceneManager.GetActiveScene();
        string scenename = currentscene.name;

        if (scenename == "GamePlay_Level1")
        {
            level = 1;
        }
        else if (scenename == "Level 2")
        {
            level = 2;
        }
    }
    void Update()
    {
        Score.text = "Coin Collection: " + score;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RB.velocity = transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            RB.velocity = -transform.forward * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RB.velocity = transform.right * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity = -transform.right * speed * Time.deltaTime;
        }
        else
        {
            RB.velocity = new Vector3(0, 0, 0);
        }

        if (score == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            print("collect");
            score++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Walls")
        {
            print("die");
            SceneManager.LoadScene("GameLose");
        }
    }
}