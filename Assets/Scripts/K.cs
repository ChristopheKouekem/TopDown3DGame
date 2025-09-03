using UnityEngine;

public class K : MonoBehaviour
{
    public float moveSpeed = 25f;
    public float scrollSpeed = 10f;
    public float minY = 4f;
    public float maxY = 50f;

    void Update()
    {
        Vector3 movement = Vector3.zero;


        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
        if (scroll < 0f)
        {
            transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
        }


        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }


        transform.position += movement * moveSpeed * Time.deltaTime;


        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}