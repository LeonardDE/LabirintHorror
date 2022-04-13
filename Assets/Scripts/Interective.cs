using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Color = UnityEngine.Color;

public class Interective : MonoBehaviour
{
   [SerializeField] private Camera _fpcCamera;
   [SerializeField] private GameObject _textCountOfPlates;
   [SerializeField] private GameObject _marker;

   private Ray _ray;
   private RaycastHit _hit;

   private float _maxDistanceRay = 1;

   public int countOfPLates = 0;

   public Vector3 ExitPosition;

   public bool ExitButtonOnScreen = false;
   
   public bool _playerLoud = false;
   

   private void Update()
   {
      Ray();
   }
   
   private void Ray()
   {
      _ray = _fpcCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2 ));
      Physics.Raycast(_ray, out _hit, _maxDistanceRay);
      Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
      

      if (_hit.collider != null && _hit.collider.gameObject.tag == "Plate" )
      {
         ExitButtonOnScreen = true;
         if (Input.GetKey(KeyCode.E))
         {
            _hit.collider.gameObject.transform.position = ExitPosition;
            countOfPLates += 1;
            _textCountOfPlates.GetComponent<Text>().text = Convert.ToString(countOfPLates);

         }
      }
      else
      {
         ExitButtonOnScreen = false;
      }

      if (_hit.collider != null && _hit.collider.gameObject.tag == "Ground")
      {
         //PlayerLoud(_hit.point, CulcRotate(_hit.point, -_hit.collider.transform.position));
         PlayerLoud(_hit.point);
      }
      else
      {
         _playerLoud = false;
      }
   }

   //private void PlayerLoud(Vector3 pos, Vector3 relativePos)
   private void PlayerLoud(Vector3 pos)
   {
      _playerLoud = Input.GetKeyDown(KeyCode.Space);
      

      if (_playerLoud)
      {
         //Instantiate(_marker, pos, Quaternion.LookRotation(relativePos, Vector3.up));
         Instantiate(_marker, pos, Quaternion.identity);
      }
   }

   /*private Vector3 CulcRotate(Vector3 point, Vector3 position)
   {
      Vector3 v = position - point;

      if (v.x == 0.5f)
      {
         v = new Vector3(1,0,0);
      }
      else if (v.x == -0.5f)
      {
         v = new Vector3(-1,0,0);
      }
      else if (v.y == -0.5f)
      {
         v = new Vector3(0,-1,0);
      }
      else if (v.y == 0.5f)
      {
         v = new Vector3(0, 1, 0);
      }

      return v;
   }
   */
}
