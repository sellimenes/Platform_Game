// "groundCheck" ad�nda bo� obje olu�turuldu ve karakterin alt�na eklendi.
// grounCheck i�erisine boxcollider2d eklendi karakterin yere de�ip,
// de�medi�ini kontrol edecek kadar k���k �ekilde ayarland�.
// T�m zeminlere "Ground" isminde LayerMask eklenmeli

using UnityEngine;
using UnityEngine.SceneManagement;


public class CharMov : MonoBehaviour
{

    public float speed; // �nerilen de�er 10
    public float jumpForce; // �nerilen de�er 40
    public Transform GroundCheck; // Karakter alt�na eklenen bo� ��e eklenecek
    public LayerMask groundlayer; // T�m zeminlere "Ground" layer verildi
    public float charScale; // Karakter x boyutu girilecek
    public Animator animator; // Animator icin referans al�nd�

    private float move;
    bool isGrounded;
    float horizontalMove = 0f;

    Rigidbody2D rb; // �nerilen Gravity 25
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D referans� al�nd�
    }


    void Update()
    {
        Run();
        Jump();
        //Animation();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundlayer); // S�rekli olarak karakter zeminde mi kontrol ediyor
    }


    void Run()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Karakter y�n de�i�tirme ba�lang��
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -charScale;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = charScale;
        }
        transform.localScale = characterScale;
        // Karakter y�n de�i�tirme biti�
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            
        }
    }

    void Animation()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "deadarea")
        {
            SceneManager.LoadScene(0);
        }
    }

}
