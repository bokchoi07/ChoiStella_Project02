using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.5f;

    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveVertical();
        MoveHorizontal();
    }

    public void MoveVertical()
    {
        float moveAmountThisFrame = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        rb.MovePosition(rb.position + moveOffset);
    }

    public void MoveHorizontal()
    {
        float moveAmountThisFrame = Input.GetAxis("Horizontal") * moveSpeed;
        Vector3 moveOffset = transform.right * moveAmountThisFrame;
        rb.MovePosition(rb.position + moveOffset);
    }
}
