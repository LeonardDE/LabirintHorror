using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject _textYouWin;
    private float _timeYouWin = 0;
    
    private void Update()
    {
        if (_timeYouWin > 0)
        {
            _timeYouWin -= Time.deltaTime;
        }
        else if (_timeYouWin < 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _timeYouWin = 3;
            _textYouWin.SetActive(true);
        }
    }
}
