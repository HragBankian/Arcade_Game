using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5f;  // Adjust the speed as needed
    public float minY = -10f;   // Minimum Y position
    public float maxY = 0f;  // Maximum Y position

    void Update()
    {
        // Get the vertical input (up and down arrow keys, or joystick)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position based on the input and speed
        float newPositionY = transform.position.y + verticalInput * speed * Time.deltaTime;

        // Clamp the position to stay within the minY and maxY limits
        newPositionY = Mathf.Clamp(newPositionY, minY, maxY);

        // Update the position of the sphere
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
