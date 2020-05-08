using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public Button restartbutton;
    // Start is called before the first frame update
    void Start()
    {
        Button restart = restartbutton.GetComponent<Button>();

        restartbutton.onClick.AddListener(RestartOnClick);
    }

    void RestartOnClick()
    {
        print("Restarted");
        SceneManager.LoadScene("GamePlay_Level1");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
