using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    private GameController _GameController;
    private Rigidbody2D playerRb;
    private Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded, disparo;
    private int speedX, extraJump;
    private float speedY;

    public Transform groundCheck, armaPosition;
    public GameObject cenouraProjetilPrefab, ovoProjetilPrefab;
    public LayerMask whatIsGround;
    public int pulosExtras;
    public bool isOlhandoEsquerda;
    public float speed, jumpForce, delayEntreDisparos, forcaTiro, forcaTiroX, forcaTiroY;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        extraJump = pulosExtras;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.02f, whatIsGround);
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            speedX = 1;
        }
        else
        {
            speedX = 0;
        }

        if (isOlhandoEsquerda == true && horizontal > 0)
        {
            Flip();
        }
        if (isOlhandoEsquerda == false && horizontal < 0)
        {
            Flip();
        }

        speedY = playerRb.velocity.y;
        playerRb.velocity = new Vector2(horizontal * speed, speedY);

        if (isGrounded == true)
        {
            extraJump = pulosExtras;
        }

        if(Input.GetButtonDown("Jump") && extraJump > 0)
        {
            Jump();
            extraJump--;
        }
        else if(Input.GetButtonDown("Jump") && extraJump == 0 && isGrounded == true)
        {
            Jump();
        }

        if (Input.GetButton("Fire1") && _GameController.municao > 0 && disparo == false)
        {
            AtirarCenoura();
        }
        if (Input.GetButton("Fire2") && _GameController.municaoGranada > 0 && disparo == false)
        {
            AtirarGranada();
        }
    }

    private void LateUpdate()
    {
        playerAnimator.SetInteger("speedX", speedX);
        playerAnimator.SetFloat("speedY", speedY);
        playerAnimator.SetBool("grounded", isGrounded);
    }

    //Função responsável em virar o personagem
    private void Flip()
    {
        isOlhandoEsquerda = !isOlhandoEsquerda;
        float x = transform.localScale.x;
        x *= -1; //Inverte o sinal do scale
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        //Utlizando o flip X
        //spriteRenderer.flipX = isOlhandoEsquerda;

        forcaTiroX *= -1;
    }

    public void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
        playerRb.AddForce(new Vector2(0, jumpForce));
    }

    private void AtirarCenoura()
    {
        disparo = true;
        StartCoroutine("DeleyTiro");
        _GameController.GerenciarMunicao(-1);
        GameObject temp = Instantiate(cenouraProjetilPrefab);
        temp.transform.position = armaPosition.position;
        //temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaTiroX,0));
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaTiro,0);

        Destroy(temp, 1.5f);
    }

    private void AtirarGranada()
    {
        disparo = true;
        StartCoroutine("DeleyTiro");
        _GameController.GerenciarMunicaoGranada(-1);
        GameObject temp = Instantiate(ovoProjetilPrefab);
        temp.transform.position = armaPosition.position;
        temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaTiroX, forcaTiroY));
        Destroy(temp, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coletavel":
                {
                    IdColetavel idc = collision.gameObject.GetComponent<IdColetavel>();

                    switch (idc.nomeItem)
                    {
                        case "Municao":
                            {
                                _GameController.GerenciarMunicao(idc.qtd);
                                break;
                            }
                        case "Ovo":
                            {
                                _GameController.GerenciarMunicaoGranada(idc.qtd);
                                break;
                            }
                        default:
                            break;
                    }
                    Destroy(collision.gameObject);
                    break;
                }
            default:
                break;
        }
    }

    IEnumerator DeleyTiro()
    {
        yield return new WaitForSeconds(delayEntreDisparos);
        disparo = false;
    }
}
