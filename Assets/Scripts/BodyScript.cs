using UnityEngine;

public class BodyScript : MonoBehaviour
{
    public Transform ObjectBefore;
    public float Speed;

    private float _currentXTarget;
    private Rigidbody myrigidbody;

    private void Start()
    {
        transform.position = ObjectBefore.localPosition + new Vector3(0, 0, -2);
        transform.rotation = Quaternion.identity;
        myrigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(ObjectBefore);
        _currentXTarget = ObjectBefore.position.x - transform.position.x;
        myrigidbody.AddForce(new Vector3(_currentXTarget, 0f, 0f).normalized * (Speed * Mathf.Abs(_currentXTarget)) * Time.smoothDeltaTime);
        myrigidbody.velocity = myrigidbody.velocity * 0.7f;
        if ((transform.position.x < -9) || (transform.position.x > 9))
        {
            float xPosition = Mathf.Clamp(transform.position.x, -9, 9);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
            myrigidbody.velocity = Vector3.zero;

        }
    }

}
