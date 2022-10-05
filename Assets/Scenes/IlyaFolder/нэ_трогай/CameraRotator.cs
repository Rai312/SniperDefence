using UnityEngine;
using UnityEngine.Playables;

public class CameraRotator : MonoBehaviour
{
  [SerializeField] private float _sensitivity;
  [SerializeField] private float _xMinimumClamp;
  [SerializeField] private float _xMaximumClamp;
  [SerializeField] private float _yMinimumClamp;
  [SerializeField] private float _yMaximumClamp;
  [SerializeField] private float _xStartRotation;
  
  private Camera _camera;
  private Vector3 _firstPoint;
  private Vector3 _secondPoint;
  private float _xRotation;
  private float _yRotation;
  private float _tempXrotation;
  private float _tempYrotation;
  private bool _isStartZoom = true;
  
  private void Awake()
  {
    _camera = GetComponent<Camera>();
  }

  void Update()
  {
    GetTouch();
    Turn();
  }

  private void GetTouch()
  {
    if (Input.touchCount > 0)
    {
      if (Input.GetTouch(0).phase == TouchPhase.Began)
      {
        _firstPoint = Input.GetTouch(0).position;
        _tempYrotation = _yRotation;
        _tempXrotation = _xRotation;
      }

      if (Input.GetTouch(0).phase == TouchPhase.Moved)
      {
        _secondPoint = Input.GetTouch(0).position;
        _yRotation = (_tempYrotation + (_secondPoint.x - _firstPoint.x) * _sensitivity / Screen.width);
        _xRotation = (_tempXrotation + (_secondPoint.y - _firstPoint.y) * _sensitivity / Screen.width);
      }

      if (Input.GetTouch(0).phase == TouchPhase.Ended)
      {
        _tempYrotation = _yRotation;
        _tempXrotation = _xRotation;
      }
    }
  }

  private void Turn()
  {
    float zeroAngle = 0f;

    if (_isStartZoom == true)
    {
      _xRotation = -_xStartRotation;
      _isStartZoom = false;
    }
    
    _xRotation = Mathf.Clamp(_xRotation, _xMinimumClamp, _xMaximumClamp);
    _yRotation = Mathf.Clamp(_yRotation, _yMinimumClamp, _yMaximumClamp);
    transform.localRotation = Quaternion.Euler(-_xRotation, _yRotation, zeroAngle);
  }
}