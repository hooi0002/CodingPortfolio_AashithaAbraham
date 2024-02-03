using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float smooth;
    public float swayMultiplier;

    // Update is called once per frame
    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        // Calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(mouseY, Vector3.right); // Yawing
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up); // Pitching

        // Resultant rotation
        Quaternion targetRotation = rotationX * rotationY;

        // Apply the rotation
        // Slerp - to interpolate between two extremes (point A and B)
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}
