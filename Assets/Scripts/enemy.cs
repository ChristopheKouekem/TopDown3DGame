using System.Threading;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    float count;
    Vector3 direction = Vector3.back;
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > 2.5f)
        {
            direction *= 1;
            count = 0;
        }
        transform.position += direction * Time.deltaTime;
    }
}
