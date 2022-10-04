using System;
using UnityEngine;

public class OpticalSight : MonoBehaviour
{
  [SerializeField] private float startZoom;
  [SerializeField] private Texture2D mainTex;

  private Camera _camera;
  private float _maximuFov = 60;
  private float _minimumFOV = 1;
  private float _speed = 10;
  private float _zoom;
  private bool _isZoomStart;
  private bool _isZoom;

  private void Awake()
  {
    _camera = GetComponent<Camera>();
  }

  void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.phase == TouchPhase.Moved)
      {
      }
    }

    if (Input.GetMouseButton(1))
    {
      _isZoom = true;

      if (_isZoomStart == false)
      {
        _isZoomStart = true;
        _zoom = _maximuFov - startZoom;
      }
    }
    else
    {
      _isZoomStart = false;
      _isZoom = false;
      _zoom = _maximuFov;
    }

    _zoom = Mathf.Clamp(_zoom, _minimumFOV, _maximuFov);
    _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoom, _speed * Time.deltaTime);
  }

  private void OnGUI()
  {
    if (_isZoom == true)
    {
      GUI.depth = 999;
      int horizontal = Screen.width;
      int vertical = Screen.height;
      GUI.DrawTexture(new Rect((horizontal - vertical) / 2, 0, vertical, vertical), mainTex);
    }
  }
}