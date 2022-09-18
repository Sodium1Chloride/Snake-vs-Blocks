using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public GameObject Head;
    public List<Transform> Body = new();
    public PlayerVariables PlayerInfo;
    public LevelMovement Level;
    public float Timer;
    public bool CanMove;
    public AudioSource Audio;
    public ParticleSystem Particles;
    public Vector3 ParticlesOffset;

    private GameObject _camera;
    private Mouse _mouse;
    private float _timer;
    private Rigidbody myrigidbody;
    private float _currentXTarget;
    private float _timerMinus = 0;


    private void Start()
    {
        _camera = Camera.main.gameObject;
        _mouse = _camera.GetComponent<Mouse>();
        myrigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            _currentXTarget = _mouse.CurrentMouseXPosition - transform.position.x;
            myrigidbody.AddForce(new Vector3(_currentXTarget, 0f, 0f).normalized * (Speed * Mathf.Abs(_currentXTarget)) * Time.smoothDeltaTime);
            myrigidbody.velocity = myrigidbody.velocity * 0.8f;
        }

        if ((transform.position.x < -9 ) || (transform.position.x > 9))
        {
            float xPosition = Mathf.Clamp(transform.position.x, -9, 9);
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
            myrigidbody.velocity = Vector3.zero;

        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out CubeGenerator Cube))
        {
            return;
        }
        Vector3 normal = collision.contacts[0].normal.normalized;
        float verticalDot = Vector3.Dot(normal, Vector3.forward);


        if (verticalDot == -1)
        {
            if (_timer <= 0)
            {
                PlayerInfo.RemovePieceOfBody();
                Audio.Play();
                Cube.CurrentHP--;
                Particles.transform.position = Head.transform.position + ParticlesOffset;
                Particles.Play();
                if (Cube.CurrentHP <= 0)
                {
                    PlayerInfo.AddScore(Cube.HP);
                    Cube.DestroyMe();
                    Level.Wait = false;
                    _timerMinus = 0;
                    return;
                }
                Level.Wait = true;
                _timer = Timer - _timerMinus;
                _timerMinus = _timer <= 0.03f ? _timerMinus : _timerMinus + 0.01f;
            }
            else
            {
                _timer -= Time.deltaTime;
            }

        }

    }


    private void OnCollisionExit(Collision collision)
    {
        if (!collision.collider.TryGetComponent(out CubeGenerator _))
        {
            return;
        }
        Level.Wait = false;
        _timerMinus = 0;
    }

    public void AddLength(int length)
    {
        PlayerInfo.PlayerLength += length;
        PlayerInfo.AddLength();
    }


    public void SetLengthBack()
    {
        transform.gameObject.SetActive(true);
        PlayerInfo.PlayerLength = 4;
        PlayerInfo.AddLength();
    }

}
