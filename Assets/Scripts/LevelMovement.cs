using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public float Speed;
    public bool Wait;




    void Update()
    {
        if (Wait)
        {
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - Vector3.forward, Speed * Time.deltaTime);
        }
    }


}
