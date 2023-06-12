using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
   
    public ParticleSystem sangueParticulaPrefab;

    [SerializeField] int vida;
    [SerializeField] Transform[] pontosDeChegagem;
    [SerializeField] float velocidade;
    [SerializeField] float distanciaCacada;
    [SerializeField] float stunTime, tempoIdle;
    [SerializeField] int dano;
    Vector3 posicaoTela;
    Animator anim;
    Player player;
    int checando;
    float stunado;
    float sVel;
    bool stun = false;
    bool atacando;
    bool patrulando = false;
    bool idle;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (player.morreu == true)
        {
            Patrulha();
        }
        posicaoTela = Camera.main.WorldToScreenPoint(transform.position);
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= distanciaCacada && !stun && player.escondido == false)
        {
            if (player.morreu == false)
            {
                Atacar();
            }
            Atacar();
        }



        else
        {
            Patrulha();
        }
    }

    private void Update()
    {
        if (stunado < Time.time && stun)
        {
            stun = false;
            anim.SetBool("Atordoado", false);
        }
    }

    public void Patrulha()
    {

        


        if (pontosDeChegagem.Length <= checando)
        {
            StartCoroutine(AnimacaoIdle());
            checando = 0;
           

        }
        else if (Vector2.Distance(transform.position, pontosDeChegagem[checando].position) < 0.5f)
        {
            checando++;
            StartCoroutine(AnimacaoIdle());
            

        }
        else if (!stun)
        {
            if(idle == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, pontosDeChegagem[checando].position, velocidade * Time.deltaTime);
            }
            
            if (transform.position.x < pontosDeChegagem[checando].position.x && idle == false)
            {
                
                transform.eulerAngles = new Vector2(0, 180);
                //Debug.Log("Flipou");
            }
            else if (transform.position.x > pontosDeChegagem[checando].position.x && idle == false)
            {
                
                transform.eulerAngles = new Vector2(0, 0);
                //Debug.Log("Flipou 0");
            }
        }
    }

    public void Atacar()
    {
        

        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Seguir").transform.position, velocidade * Time.deltaTime);
        Debug.Log("Inimigo te viu");



        /*if (player.naoEscondido == true && patrulando == false)
        {
            Patrulha();
        }*/

        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 0.5f && !atacando)
        {
            anim.SetTrigger("Ataque");
            atacando = true;
            StartCoroutine(Ataque(1f));
        }
        if (transform.position.x > GameObject.FindGameObjectWithTag("Player").transform.position.x)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }



    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Dardo(Clone)"))
        {
            Instantiate(sangueParticulaPrefab, transform.position, Quaternion.identity);

            stun = true;
            stunado = Time.time + stunTime;
            vida -= 1;
            SalvarInformacoes.EscreverLinha("Atirou no monstro deixo ele stunado por " + stunTime + " e com vida " + vida);
            anim.SetBool("Atordoado", true);
            if (vida <= 0)
            {
                SalvarInformacoes.EscreverLinha("Matou o monstro");
                Destroy(gameObject);
            }
        }
    }

    /*void OnGUI() { 
        Rect rect = new Rect(new Vector2(posicaoTela.x + ((Screen.width * -3) / 100), Screen.height - posicaoTela.y + ((Screen.height * -17) / 100)), new Vector2(500, 450));
        GUI.skin.label.fontSize = ((Screen.width + Screen.height) * 2) / 170;
        if (stun) { 
        GUI.Label(rect, "Stunado: " + (stunado - Time.time));
        }
        else {
            GUI.Label(rect, "*Vida: " + vida + "*");
        }
    }*/
    IEnumerator Ataque(float tempo)
    {
        yield return new WaitForSeconds(0.25f);
        player.darDano(dano);
        //yield return new WaitForSeconds(tempo);
        atacando = false;

    }
    IEnumerator AnimacaoIdle()
    {
        
        idle = true;
        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(tempoIdle);
        anim.SetBool("Idle", false);
        idle = false;
        
    }
    

}