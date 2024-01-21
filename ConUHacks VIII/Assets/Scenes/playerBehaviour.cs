using System.Collections;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float minY = -5f;
    public float maxY = -1f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float newPositionY = transform.position.y + verticalInput * speed * Time.deltaTime;
        newPositionY = Mathf.Clamp(newPositionY, minY, maxY);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
    }
}
