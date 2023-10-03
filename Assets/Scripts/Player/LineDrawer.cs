using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    Color c1 = Color.white;
    Color c2 = Color.blue;
    private Rigidbody2D ball;
    public void Awake()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.SetWidth(0.2f, 0.2f);
        _lineRenderer.enabled = false;
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.SetColors(c1, c2);

        ball = gameObject.GetComponent<Rigidbody2D>();
    }

    private Vector3 _initialPosition;
    private Vector3 _currentPosition;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //_initialPosition = GetCurrentMousePosition().GetValueOrDefault();
            _initialPosition = ball.transform.position;
            _lineRenderer.SetPosition(0, _initialPosition);
            _lineRenderer.positionCount = 1;
            _lineRenderer.enabled = true;
        }
        else if (Input.GetMouseButton(0))
        {
            _lineRenderer.SetPosition(0, ball.transform.position);
            _currentPosition = GetCurrentMousePosition().GetValueOrDefault();
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(1, _currentPosition);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            _lineRenderer.enabled = false;
            var releasePosition = GetCurrentMousePosition().GetValueOrDefault();
            var direction = releasePosition - _initialPosition;
            
        }
    }

    private Vector3? GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);

        }

        return null;
    }
}
