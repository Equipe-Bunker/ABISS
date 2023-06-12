using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class InimigoPerseguidor : MonoBehaviour
{
    CaminhoPlayer caminhoPlayer;
    PerseguirPlayer perseguirPlayer;
    public Event evento;
    AudioFase audioFase;
    AudioControle audioControle;
    public ParticleSystem sangueParticulaPrefab;
    //public AudioSource audioSourceBatalha;
    //public AudioClip audioBatalha;
    [SerializeField] int vida;
    [SerializeField] Transform[] pontosDeChegagem;
    [SerializeField] Transform[] portasPatrulhas;
    
    [SerializeField] float velocidade;
    [SerializeField] float distanciaCacada;
    [SerializeField] float stunTime, tempoIdle;
    public float tempoPerseguicao;
    float tempoAtual;
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
    public bool ronda;
    bool ponto;
    bool musicaCombate;
    
    private int indexPortaAtual = 0;
    private Transform pontoAtual;
    public bool locomocao = true;
    public bool perseguicao;
    float tempoPerseguição;
    void Start()
    {

        caminhoPlayer = FindObjectOfType<CaminhoPlayer>();
        perseguirPlayer = FindObjectOfType<PerseguirPlayer>();
        audioFase = FindObjectOfType<AudioFase>();
        audioControle = FindObjectOfType<AudioControle>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();

        // Teleporta o inimigo para a primeira porta
        //pontoAtual = portasPatrulhas[0];
        //transform.position = portasPatrulhas[0].position;
        tempoAtual = tempoPerseguicao;
    }

    void FixedUpdate()
    {
        if (musicaCombate == true)
        {
            audioFase.EnemySawPlayer();
        }
        if(musicaCombate == false)
        {
            audioFase.EnemyLostPlayer();
        }


       
       
        if (ronda == true)
        {

            if (vida != 0)
            {
                if (player.morreu == true)
                {

                    Ronda();
                }
                posicaoTela = Camera.main.WorldToScreenPoint(transform.position);

                if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Seguir").transform.position) <= distanciaCacada && !stun )
                {
                    if (player.morreu == true)
                    {
                        Ronda();
                    }
                    Atacar();
                    
                    /*if(!atacando && !stun && !perseguicao)
                    {
                        Debug.Log("não esta te vendo, mas ta te perseguindo");
                        player.InstanciarPonto();
                        
                        StartCoroutine(TempoPerseguicao());
                        if (tempoAtual > 0f)
                        {
                            // Reduz gradualmente o valor até 0
                            tempoAtual = Mathf.Lerp(tempoAtual, 0f, tempoPerseguicao * Time.deltaTime);
                            Debug.Log(tempoAtual);
                        }
                        indexPortaAtual = 0;
                        perseguicao = false;
                    }*/
                    
                }

                if(perseguicao == false)
                {
                    Ronda();
                    
                }
            }
        }
        else
        {
            if (vida != 0)
            {
                if (player.morreu == true)
                {

                    Patrulha();
                }
                posicaoTela = Camera.main.WorldToScreenPoint(transform.position);

                if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= distanciaCacada && !stun && player.escondido == false)
                {
                    if (player.morreu == true)
                    {
                        Patrulha();
                    }
                    Atacar();
                }

                else
                {
                    Patrulha();
                }
            }
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
        musicaCombate = false;
        //audioFase.EnemyLostPlayer();


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

    float distanciaLimite = 0.1f; // Distância limite para considerar que o objeto alcançou a porta
    private bool chegouNaPorta = false;
    private float tempoChegadaPorta;

    public void Ronda()
    {
        musicaCombate = false;
        //audioFase.EnemyLostPlayer();

        float distancia = Vector2.Distance(transform.position, portasPatrulhas[indexPortaAtual].position);

        if (distancia < distanciaLimite)
        {
            if (!chegouNaPorta)
            {
                chegouNaPorta = true;
                tempoChegadaPorta = Time.time;
                StartCoroutine(AnimacaoIdleRonda());
            }
        }
        
        else
        {
            chegouNaPorta = false;
        }

        if (indexPortaAtual >= portasPatrulhas.Length)
        {
            indexPortaAtual = 0;
        }

        if (locomocao)
        {
            transform.position = Vector2.MoveTowards(transform.position, portasPatrulhas[indexPortaAtual].position, velocidade * Time.deltaTime);
        }
        else
        {
            transform.position = portasPatrulhas[indexPortaAtual].position;
        }

        if (!stun)
        {
            

            if (transform.position.x < portasPatrulhas[indexPortaAtual].position.x && idle == false)
            {

                transform.eulerAngles = new Vector2(0, 180);
                //Debug.Log("Flipou");
            }
            else if (transform.position.x > portasPatrulhas[indexPortaAtual].position.x && idle == false)
            {

                transform.eulerAngles = new Vector2(0, 0);
                //Debug.Log("Flipou 0");
            }
        }

    }
    
    
    
    private IEnumerator TempoPerseguicao()
    {
        Debug.Log("perseguição ativa");
        perseguicao = true;
        //caminhoPlayer.Perseguicao();
        yield return new WaitForSeconds(tempoPerseguicao);
        perseguicao = false;
        //caminhoPlayer.Perseguicao();
        Debug.Log("Desativada");
    }




    public void TrocarBool()
    {
        locomocao = !locomocao;
    }

    public void Atacar()
    {
        musicaCombate = true;
        //audioFase.EnemySawPlayer();
        if (!atacando)
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Seguir").transform.position, velocidade * Time.deltaTime);
            Debug.Log("Inimigo te viu");
        }

        

        

        /*if (player.Escondido == true && patrulando == false)
        {
            Patrulha();
        }*/

        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 0.5f && !atacando)
        {
            anim.SetBool("Ataque", true);
            
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
        if (col.gameObject.name.Equals("Dardo(Clone)") && vida > 0)
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
                //Destroy(gameObject);
                StartCoroutine(Morte());
            }
        }

        /*if (col.CompareTag("PontoPerseguir"))
        {
            ponto = true;
        }*/

    }


    /*void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("PontoPatrulha"))
        {
            ponto = false;
        }
    }*/

    IEnumerator Morte()
    {
        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Morto", true);
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Morto", false);
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
        
        yield return new WaitForSeconds(0.5f);
        player.darDano(dano);
        yield return new WaitForSeconds(tempo);
        atacando = false;
        anim.SetBool("Ataque", false);
        
    }
    IEnumerator AnimacaoIdle()
    {
        
        idle = true;
        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(tempoIdle);
        anim.SetBool("Idle", false);
        idle = false;
        
    }
    IEnumerator AnimacaoIdleRonda()
    {

        idle = true;
        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(tempoIdle);
        anim.SetBool("Idle", false);
        idle = false;

        // Trocar o índice
        indexPortaAtual++;
        Debug.Log("Valor de indexPortaAtual depois do incremento: " + indexPortaAtual);


        if (indexPortaAtual >= portasPatrulhas.Length)
        {
            indexPortaAtual = 0;
        }


        TrocarBool();
        chegouNaPorta = false;
    }


    public void LocalizacaoPlayer()
    {
        
        if (perseguirPlayer.playerEstaAqui == true)
        {
            Debug.Log("O jogador está aqui");
        }
    }

}

