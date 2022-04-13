using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject _gameOver;
    private float _timeYouDied = 0f;

    private void Update()
    {
        if (_timeYouDied > 0)
        {
            _timeYouDied -= Time.deltaTime;
        }
        else if (_timeYouDied < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _timeYouDied = 5;
            other.gameObject.GetComponent<Pcontroller>().enabled = false;
            other.gameObject.GetComponentInChildren<Camera>().GetComponent<CameraFollowToMouse>().enabled = false;
            _gameOver.SetActive(true);
        }
    }

}
