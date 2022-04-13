using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour
{
    public Interective _Interective;
    public GameObject _textDoorOpen;

    public GameObject _leftDoor;
    public GameObject _rightDoor;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Interective.countOfPLates == 6)
        {
            OpenTheDoor();
        }
    }

    private void OpenTheDoor()
    {
        _textDoorOpen.SetActive(true);
        _leftDoor.transform.rotation = Quaternion.Euler(0,-90,0);
        _rightDoor.transform.rotation = Quaternion.Euler(0,90,0);
    }
}
