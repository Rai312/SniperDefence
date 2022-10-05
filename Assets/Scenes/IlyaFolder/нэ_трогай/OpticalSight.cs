using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class OpticalSight : MonoBehaviour
{
  [SerializeField] private float _startZoom;
  [SerializeField] private GameObject _sight;

  private Camera _camera;
  private float _maximuFov = 60;
  private float _targetZoom;
  private float _duration = 1f;

  public event Action SightIsReleased;

  private void Awake()
  {
    _camera = GetComponent<Camera>();
  }

  private void Update()
  {
    EnableSight();
  }
  
  public void EnableSight()
  {
    if (Input.touchCount > 0)
    {
      if (Input.GetTouch(0).phase == TouchPhase.Began)
      {
        _sight.SetActive(true);
        _targetZoom = _maximuFov - _startZoom;
        _camera.DOFieldOfView(_targetZoom, _duration);
      }

      if (Input.GetTouch(0).phase == TouchPhase.Ended)
      {
        _sight.SetActive(false);
        _targetZoom = _maximuFov;
        _camera.DOFieldOfView(_maximuFov, _duration);
        SightIsReleased?.Invoke();
      }
    }
  }
}