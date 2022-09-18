using TMPro;
using UnityEngine;

public class BonusScript : MonoBehaviour
{
    public TextMeshPro Text;

    private int _bonus;
    // Start is called before the first frame update
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
        Destroy(transform.gameObject);
    }
}
