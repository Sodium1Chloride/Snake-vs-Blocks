using TMPro;
using UnityEngine;
using System.Collections;

public class BonusScript : MonoBehaviour
{
    public TextMeshPro Text;
    public AudioSource Audio;
    public Transform[] Items;
    public Collider Collider;
    public ParticleSystem Particles;

    private int _bonus;

    void Start()
    {
        _bonus = Random.Range(1, 5);
        Text.SetText(_bonus.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.TryGetComponent<Player>(out Player player))
        {
            return;
        }
        player.AddLength(_bonus);
        foreach (Transform a in Items)
        {
            a.transform.gameObject.SetActive(false);
        }
        Particles.transform.position = transform.position;
        Particles.Play();
        Collider.enabled = false;
        Audio.Play();
        Destroy(transform.gameObject, Particles.main.startLifetime.constant);
    }

}
