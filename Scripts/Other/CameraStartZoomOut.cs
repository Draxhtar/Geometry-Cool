using UnityEngine;
using DG.Tweening;

public class CameraStartZoomOut : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float duration = 1f;
    [SerializeField] float normal = 5f;
    
    void Start()
    {
        _camera.DOOrthoSize(normal, duration);
    }
}
