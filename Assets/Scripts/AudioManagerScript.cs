using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    private float Ver;
    private float Hor;

    public AudioClip _breath;
    public AudioClip _shagi;

    public AudioSource _source;

    private Pcontroller _pController;

    private float _nextStepTime = 0.8f;
    private float _nextStepRunTime = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        _pController = GetComponent<Pcontroller>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ver = Input.GetAxis("Vertical");
        Hor = Input.GetAxis("Horizontal");
        
        PlayeBreathAudio();
        PlayerShagiAudio();
    }

    public void PlayeBreathAudio()
    {
        if (_pController.staminaValue <= 0)
        {
            _source.PlayOneShot(_breath);
        }
    }

    public void PlayerShagiAudio()
    {
        if (Mathf.Abs(Hor) + Mathf.Abs(Ver) >= 1 && !Input.GetKey(KeyCode.LeftShift))
        {
            if (_nextStepTime == 0.8f)
            {
                _source.PlayOneShot(_shagi);    
            }

            _nextStepTime -= Time.deltaTime;

            if (_nextStepTime <= 0)
            {
                _nextStepTime = 0.8f;
            }
        }
        else if (Mathf.Abs(Hor) + Mathf.Abs(Ver) >= 1 && Input.GetKey(KeyCode.LeftShift) && !_pController.staminBelowZero)
        {
            if (_nextStepRunTime == 0.4f)
            {
                _source.PlayOneShot(_shagi);    
            }

            _nextStepRunTime -= Time.deltaTime;

            if (_nextStepRunTime <= 0)
            {
                _nextStepRunTime = 0.4f;
            }
        }

    }
}
