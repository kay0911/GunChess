using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 moveInput;
    private Rigidbody2D rb;
    public SpriteRenderer characterSR;
    public Animator animator;
    public GameObject SB;
    public StaticBase sb;

    public float dashBoost = 3f;
    private float dashTime;
    public float DashTime;
    bool dashOnce = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SB = GameObject.Find("StaticBase");
        sb = SB.GetComponent<StaticBase>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += sb.PlayerMoveSpeed * Time.deltaTime * moveInput;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && dashTime <= 0)
        {
            animator.SetBool("dash", true);
            sb.PlayerMoveSpeed += sb.DashSpeed;
            dashTime = DashTime;
            dashOnce = true;
        }
        if (dashTime <= 0 && dashOnce == true)
        {
            animator.SetBool("dash", false);
            sb.PlayerMoveSpeed -= sb.DashSpeed;
            dashOnce = false;

        }
        else
        {
            dashTime -= Time.deltaTime;
        }

        if (moveInput.x != 0)
        {
            if (moveInput.x < 0)
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(1, 1, 0);
        }

    }
    

}
