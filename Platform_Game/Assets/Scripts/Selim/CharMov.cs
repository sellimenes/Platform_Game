// "groundCheck" adýnda boþ obje oluþturuldu ve karakterin altýna eklendi.
// grounCheck içerisine boxcollider2d eklendi karakterin yere deðip,
// deðmediðini kontrol edecek kadar küçük þekilde ayarlandý.
// Tüm zeminlere "Ground" isminde LayerMask eklenmeli

using UnityEngine;
using UnityEngine.SceneManagement;


public class CharMov : MonoBehaviour
{

    public float speed; // Önerilen deðer 10
    public float jumpForce; // Önerilen deðer 40
    public Transform GroundCheck; // Karakter altýna eklenen boþ öðe eklenecek
    public LayerMask groundlayer; // Tüm zeminlere "Ground" layer verildi
    public float charScale; // Karakter x boyutu girilecek
    public Animator animator; // Animator icin referans alýndý

    private float move;
    bool isGrounded;
    float horizontalMove = 0f;

    Rigidbody2D rb; // Önerilen Gravity 25
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D referansý alýndý
    }


    void Update()
    {
        Run();
        Jump();
        //Animation();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundlayer); // Sürekli olarak karakter zeminde mi kontrol ediyor
    }


    void Run()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Karakter yön deðiþtirme baþlangýç
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
        // Karakter yön deðiþtirme bitiþ
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
