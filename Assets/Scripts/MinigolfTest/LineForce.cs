using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LineForce : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float forceScale = 1f;
    [SerializeField] private float stopVelocity = 0.1f;
    [SerializeField] private InputAction shootAction;
    private MinigolfInputs _inputs;
    private Rigidbody2D _rb;

    private bool _canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = new MinigolfInputs();
        _inputs.UI.Enable();
        shootAction.Enable();
        shootAction.performed += _ => HandleShoot();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_canShoot)
        {
            DrawLine(GetWorldMousePos());
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        _canShoot = CanShoot();
    }

    private void HandleShoot()
    {
        if (_canShoot)
        {
            Shoot();
        }
    }

    private bool CanShoot()
    {
        return _rb.velocity.magnitude < stopVelocity;
    }

    private void Shoot()
    {
        Vector2 worldMousePos = GetWorldMousePos();
        Vector2 direction = (worldMousePos - (Vector2)transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(direction * forceScale);
        _canShoot = false;
    }

    private Vector2 GetWorldMousePos()
    {
        Vector2 mousePos = _inputs.UI.Point.ReadValue<Vector2>();
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void DrawLine(Vector3 worldPoint)
    {
        lineRenderer.SetPositions(new Vector3[] { transform.position, worldPoint });
        lineRenderer.enabled = true;
    }
}
