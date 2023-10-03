using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera cam;
    private float targetZoom;
    [SerializeField] private float zoomFactor;
    [SerializeField] private float zoomLerp;
    [SerializeField] private Rigidbody2D rb2d;

    private void Start()
    {
        cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    private void Update()
    {
        float playerVelocity = Mathf.Clamp(rb2d.velocity.magnitude, 0, 40f);

        //targetZoom -= playerVelocity / zoomFactor;
        //targetZoom = Mathf.Clamp(targetZoom, cam.orthographicSize, 18f);
        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerp);
        if(playerVelocity >= 28f)
        {
            //10f er min zoom(standard zoom) og 16f er maks zoom ut
            float orthographicSize = Mathf.Clamp(playerVelocity * zoomFactor, 10f, 18f);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthographicSize, Time.fixedDeltaTime * zoomLerp);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 10f, Time.fixedDeltaTime);
        }

        
    }
}
