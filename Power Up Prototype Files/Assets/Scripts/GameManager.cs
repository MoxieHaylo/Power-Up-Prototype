using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("GameController");
        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
