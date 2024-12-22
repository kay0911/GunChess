using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public bool PlayerBullet;

    public GameObject SB;
    public StaticBase sb;
    void Start()
    {
        SB = GameObject.Find("StaticBase");
        sb = SB.GetComponent<StaticBase>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !PlayerBullet)
        {
            int damage = sb.BishopDam;
            collision.GetComponent<Health>().TakeDam(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy") && PlayerBullet)
        {
            int damage = sb.DamBullet;
            collision.GetComponent<Health>().TakeDam(damage);
            Destroy(gameObject);
        }
    }
}
