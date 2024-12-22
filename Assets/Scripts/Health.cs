using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{
    public bool bishop = false;
    public bool pawn = false;
    public bool queen = false;
    public bool rook = false;
    public bool knight = false;
    public bool Player = false;

    public int maxHealth;
    [HideInInspector] public int currentHealth;

    public HealthBar healthBar;

    private float safeTime;
    public float safeTimeDuration = 0f;
    public bool isDead = false;

    public bool camShake = false;

    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;

    public GameObject SB;
    public StaticBase sb;


    private void Start()
    {
        SB = GameObject.Find("StaticBase");
        sb = SB.GetComponent<StaticBase>();
        if (Player) maxHealth = sb.PlayerHP;
        if (queen) maxHealth = sb.QueenHP;
        if (rook) maxHealth = sb.RookHP;
        if (knight) maxHealth = sb.KnightHP;
        if (bishop) maxHealth = sb.BishopHP;
        if (pawn) maxHealth = sb.PawnHP;

        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth, maxHealth);
    }

    public void TakeDam(int damage)
    {
        if (safeTime <= 0)
        {
            currentHealth -= damage;
            popUpText.text = damage.ToString();
            Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (this.gameObject.tag == "Enemy")
                {
                    //FindObjectOfType<WeaponManager>().RemoveEnemyToFireRange(this.transform);
                    //FindObjectOfType<Killed>().UpdateKilled();
                    //FindObjectOfType<PlayerExp>().UpdateExperience(UnityEngine.Random.Range(1, 4));
                    Destroy(this.gameObject, 0.125f);
                }
                isDead = true;
            }

            // If player then update health bar
            if (healthBar != null)
                healthBar.UpdateHealth(currentHealth, maxHealth);

            safeTime = safeTimeDuration;
        }
    }

    private void Update()
    {
        if (safeTime > 0)
        {
            safeTime -= Time.deltaTime;
        }
    }
}
