using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] bool ativarDebug;
    //=-=-=-=-=-=-=-=-=- Publico =-=-=-=-=-=-=-=-=-=
    //Outros
    public float velocidade;
    public ScriptInventory invPlayer;
    public TextMeshProUGUI textoBarraVida;
    public GameObject barraVida;
    public Image barraStamina;
    public GameObject gameOver, CanvasTomouDano;
    public Rigidbody2D playerRig;
    [HideInInspector] public ScriptInventory inventario; //Esse eu coloquei só porque ja tem outros 30 scripts usando e mudar todos vai demorar muito

    //Float
    public float velocidadeCorrida;
    public float velocidaderastejo;
    public float estaminaMaxima;
    public float estaminaAtual;
    public float recuperacaoEstaminaPorSegundo;
    //Inteiro
    public int vida;
    //Boleanos
    public bool luzAtiva = false;
    public bool morreu = false;
    public bool escondido;
    public bool parado;
    public bool PdAgachar = false;
    public bool Andar = true;
    bool mira;
    
    
    //=-=-=-=-=-=-=-=-=-=-=-= Privado =-=-=-=-=-=-=-=-=-=-=-=
    //Outros
    [SerializeField] Image barraDeVida;
    [SerializeField] TextMeshProUGUI hudArma;
    [SerializeField] ItemSegurar selecionadoHud;
    Cura cura;
    
    AudiosPequenos audiosPequenos;
    Animator anim, animBarraVida;
    [SerializeField] private GameObject localCerto;

    //Float
    [SerializeField] float tempoTiro;
    float velocidadePadrao, velocidadedesacelerada;
    public GameObject pontoPerseguicao;
    //Inteiros
    int maxVida;
    int umavez = 0;
    int andando;
    int itemSel;
    //Boleanos
    bool correndo;
    public bool agachado;
    private bool agua;

    void Start()
    {
        
        inventario = invPlayer; // Para não ter que mudar uns 30 scripts
        velocidadePadrao = velocidade;
        velocidadedesacelerada = velocidade * 0.7f;
        cura = FindObjectOfType<Cura>();
        audiosPequenos = FindObjectOfType<AudiosPequenos>();
        maxVida = vida;
        anim = GetComponent<Animator>();
        playerRig = GetComponent<Rigidbody2D>();
        andando = 1;
        anim.SetInteger("Sel", 1);
        hudArma.text = "Mao";
        agua = false;
        
    }

    void Update()
    {
        

        if (itemSel == 3)
        {
            if (invPlayer.ProcurarItem("Arma"))
            {
                hudArma.text = selecionadoHud.ArmaSelecionada().nome + " | " + transform.GetChild(0).GetChild(0).GetComponent<Arma>().GetMunicao();
            }
        }
        
            //Animacoes --------------------------
            if (!parado && Input.GetAxis("Horizontal") > 0 && GetComponent<Rigidbody2D>().velocity.x != 0)
            {
            
            if (andando == 2)
            {
                anim.SetInteger("Andando", 2);
            }

            if (andando == 3)
            {
                anim.SetInteger("Andando", 3);
            }
            //if (agua)
            //{
            //    anim.SetInteger("Andando", 5);
            //    velocidade = velocidade * .7f;
            //}

            anim.SetInteger("Andando", andando);
            anim.SetBool("Andar", true);
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetBool("Correr", false);
            velocidade = velocidadePadrao;
        }
        else if (!parado && Input.GetAxis("Horizontal") < 0 && GetComponent<Rigidbody2D>().velocity.x != 0)
        {
            anim.SetInteger("Andando", andando);
            if (andando == 2)
            {
                anim.SetInteger("Andando", 2);
            }

            if (andando == 3)
            {
                anim.SetInteger("Andando", 3);
            }
            //if (agua)
            //{
            //    anim.SetInteger("Andando", 5);
            //}

            transform.eulerAngles = new Vector2(0, 0);
            anim.SetBool("Andar", true);
            anim.SetBool("Correr", false);
            velocidade = velocidadePadrao;
        }
      
        else
        {


            anim.SetInteger("Andando", 0);
            anim.SetBool("Andar", false);
            anim.SetBool("Correr", false);
            //andando = 0;
        }
        umavez = 0;
        //Correr
        if (Input.GetKey(KeyCode.Space) && GetComponent<Rigidbody2D>().velocity.x != 0 && velocidade < velocidadeCorrida)
        {
            if (estaminaAtual > 0)
            {
                if (!correndo) { SalvarInformacoes.EscreverLinha("Esta correndo"); }
                correndo = true;
                velocidade = velocidadeCorrida;
                estaminaAtual -= Time.deltaTime * 10;
                if (correndo == true)
                {
                    barraStamina.enabled = true;
                    umavez++;
                    anim.SetBool("Correr", true);
                    if (andando == 3)
                    {
                        anim.SetBool("Arma", true);
                    }
                    if (andando == 2)
                    {
                        anim.SetBool("Lanterna", true);
                    }
                    if (andando == 4)
                    {
                        anim.SetBool("Isquero", true);
                    }
                }
            }
            else
            {
                estaminaAtual = 0;
            }
        }
        else
        {
            if (correndo) { SalvarInformacoes.EscreverLinha("Parou correr"); }
            correndo = false;
        }

        //Stamina
        if (barraStamina)
        {
            barraStamina.fillAmount = estaminaAtual / estaminaMaxima;
            estaminaAtual += recuperacaoEstaminaPorSegundo * Time.deltaTime;
            if (estaminaAtual > estaminaMaxima)
            {
                estaminaAtual = estaminaMaxima;
                barraStamina.enabled = false;
            }
        }

        //Agachado
        if (!parado && !anim.GetBool("Andar") && (Input.GetKeyDown(KeyCode.LeftControl)  && (PdAgachar == true)|| Input.GetButtonDown("XboxRB")))
        {
            if (!anim.GetBool("Agachado"))
            {
                agachado = true;
                anim.SetBool("Agachado", true);
            }
            else
            {
                agachado = false;
                anim.SetBool("Agachado", false);
            }
        }


        //Selecionar Itens
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetAxisRaw("XboxDpadVertical") < 0)
        {
            itemSel = 1;
            SelecionarItem(false);
            luzAtiva = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetAxisRaw("XboxDpadHorizontal") > 0)
        {
            itemSel = 2;
            SelecionarItem(false);
            luzAtiva = true;
            AnimacaoParaAlucinacao();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetAxisRaw("XboxDpadVertical") > 0)
        {
            itemSel = 3;
            SelecionarItem(false);
            luzAtiva = false;


            if (itemSel == 3)
            {
                if (invPlayer.ProcurarItem("Arma"))
                {
                    hudArma.text = selecionadoHud.ArmaSelecionada().nome + " | " + transform.GetChild(0).GetChild(0).GetComponent<Arma>().GetMunicao();
                }
            }
        }

        //item de cura
        if (Input.GetKeyDown(KeyCode.Q) && !parado && invPlayer.ProcurarItem("Cura"))
        {
            Curar();
        }
        //ChamaBarraVida();

        /*if (invPlayer.ProcurarQuantidade("Bateria") <= 0)
        {
             Debug.Log("removeu bateria do inventario");
             invPlayer.RemoverItem(invPlayer.ProcurarItem("Bateria"));
        }*/

        


    }

    public void Curar()
    {
        if (vida < maxVida)
        {
            vida += 3;
            invPlayer.RemoverItem(invPlayer.ProcurarItem("Cura"), 1, true);
            if (vida > maxVida)
            {
                vida = maxVida;
            }
        }
        ChamaBarraVida();
    }

    void FixedUpdate()
    {
        if (!parado && !mira)
        {
            if (correndo == true && umavez == 1)
            {
                playerRig.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, playerRig.velocity.y);
            }
            else
            {

                playerRig.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidade, playerRig.velocity.y);
            }
            if (agachado == true)
            {
                playerRig.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidaderastejo, playerRig.velocity.y);
            }
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ColetarItem item = col.GetComponent<ColetarItem>();
        if (item)
        {
            invPlayer.AdicionarItem(item.item, item.quantidade);
            Destroy(col.gameObject);
        }
        if (col.CompareTag("Agua"))
        {
            agua = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Agua"))
        {
            agua = false;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Agua"))
        {
            agua = true;
        }
    }


    public void darDano(int _dano)
    {
        vida -= _dano;
        SalvarInformacoes.EscreverLinha("Tomou " + _dano + "de dano ficando com: " + vida + " de vida");
        StartCoroutine(DanoEfeito());
        Debug.Log(vida);
        if (vida <= 0)
        {
            morreu = true;
            SalvarInformacoes.EscreverLinha("----- Morreu -----");
            //transform.eulerAngles = new Vector3(0, 0, -90);
            parado = true;
            StartCoroutine(GameOver());
            
            
        }
        else
        {
            anim.SetBool("Morto", false);
        }
    }
   

    IEnumerator DanoEfeito()
    {
        CanvasTomouDano.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        CanvasTomouDano.SetActive(false);
    }

    IEnumerator GameOver()
    {
        anim.SetBool("Morto", true);
        yield return new WaitForSeconds(1.5f);
        gameOver.SetActive(true);
        
    }
    IEnumerator AnimaçãoMorte()
    {
        anim.SetBool("Morto", true);
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(GameOver());

    }

    void OnApplicationQuit()
    {
        invPlayer.inventario.Clear();
    }

    //============================================= Métodos ==============================================
    //Aqui ele coloca o item na cena depois de selecionado
    void InstanciarItem(Item item)
    {
        if (transform.GetChild(0).childCount >= 1)
        {
            Destroy(transform.GetChild(0).GetChild(0).gameObject);
        }
        Debug.Log("Item Instanciado (na mão): " + item.nome);
        GameObject obj = Instantiate(item.prefab, transform.GetChild(0).position, transform.GetChild(0).rotation);
        obj.transform.SetParent(transform.GetChild(0));
    }
    //Aqui ele seleciona o item no inventario
    public void SelecionarItem(bool ignorarParado)
    {
        if ((!parado || ignorarParado) && itemSel == 1)
        {
            if (transform.GetChild(0).childCount >= 1)
            {
                Destroy(transform.GetChild(0).GetChild(0).gameObject);
            }
            hudArma.text = "Mao";
            SetAnimacao("Mao");
        }
        else if ((!parado || ignorarParado) && itemSel == 2)
        {
            if (selecionadoHud.LuzSelecionada() != null)
            {
                InstanciarItem(selecionadoHud.LuzSelecionada());
                hudArma.text = selecionadoHud.LuzSelecionada().nome;
                SetAnimacao(selecionadoHud.LuzSelecionada().nome);
                
            } else { Debug.Log("Sem Item para iluminacao"); }
        }
        else if ((!parado || ignorarParado) && itemSel == 3)
        {
            if (selecionadoHud.ArmaSelecionada() != null)
            {
                InstanciarItem(selecionadoHud.ArmaSelecionada());
                hudArma.text = selecionadoHud.ArmaSelecionada().nome;
                SetAnimacao(selecionadoHud.ArmaSelecionada().nome);
            } else { Debug.Log("Sem Armas"); }
        }
    }

    void SetAnimacao(string nomeItem)
    {
        if (nomeItem.Contains("Lanterna"))
        {
            anim.SetInteger("Sel", 2);
            anim.SetBool("Lanterna", true);
            anim.SetBool("Arma", false);
            anim.SetBool("Isqueiro", false);
            andando = 2;

        }
        
        else if (nomeItem.Contains("Isqueiro"))
        {
            anim.SetInteger("Sel", 2);
            anim.SetBool("Isqueiro", true);
            anim.SetBool("Arma", false);
            anim.SetBool("Lanterna", false);
            andando = 4;

        }

        else if (nomeItem.Contains("Arma de Pregos"))
        {
            anim.SetInteger("Sel", 3);
            anim.SetBool("Arma", true);
            anim.SetBool("Isqueiro", false);
            anim.SetBool("Lanterna", false);
            andando = 3;
        }
        
        else
        {
            anim.SetInteger("Sel", 1);
            anim.SetBool("Lanterna", false);
            anim.SetBool("Arma", false);
            anim.SetBool("Isqueiro", false);
            andando = 1;

        }
    }
    public IEnumerator AnimacaoTiro(float tempo) //Chamado na arma, por enquanto como só tem 1 arma não tem mais variaçoes
    {
        SetParado(true);
        anim.SetTrigger("Atirar");
        yield return new WaitForSeconds(tempo);
        SetParado(false);
    }
    public void AnimacaoMira()
    {
        
        mira = true;
        anim.SetBool("Mira", true);
        
        
    }
    /*public IEnumerator AtivaSomMira()
    {
        yield return new WaitForSeconds(0.01f);
        audiosPequenos.SomMira();
    }*/
    public void AnimacaoTiraMira()
    {
        anim.SetBool("Mira", false);
        mira = false;
    }

    public void AnimacaoAlucinacao()
    {
        anim.SetBool("Alucinacao", true);
    }

    public void AnimacaoParaAlucinacao()
    {
        anim.SetBool("Alucinacao", false);
    }
    public void AnimacaoMorte()
    {
        anim.SetBool("Morto", true);
        anim.SetBool("ContinuarMorto", true);
        StartCoroutine(AnimaçãoMorte());

        SetParado(true);
    }

    public void ChamaBarraVida()
    {
        animBarraVida = barraVida.GetComponent<Animator>();
        if (vida >= maxVida - 2)
        {
            textoBarraVida.text = "Status / Bom";
            animBarraVida.SetBool("VidaCheia", true);
            animBarraVida.SetBool("VidaMedia", false);
            animBarraVida.SetBool("VidaBaixa", false);
        }
        else if (vida == maxVida - 3 || vida == maxVida - 4)
        {
            textoBarraVida.text = "Status / Atenção";
            animBarraVida.SetBool("VidaMedia", true);
            animBarraVida.SetBool("VidaCheia", false);
            animBarraVida.SetBool("VidaBaixa", false);
        }
        else if (vida < maxVida - 4)
        {
            textoBarraVida.text = "Status / Perigo";
            animBarraVida.SetBool("VidaBaixa", true);
            animBarraVida.SetBool("VidaCheia", false);
            animBarraVida.SetBool("VidaMedia", false);
        }
    }

    public void Flip()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
    public void InstanciarPonto()
    {
        Instantiate(pontoPerseguicao);
    }

    

    public void AtivarEsconder()
    {
        escondido = true;
        Debug.Log("Ta escondido");
    }
    public void DesativarEsconder()
    {
        escondido = false;
        Debug.Log("nao esta escondido");
    }

    // ----------------- GETS e SETS ------------------
    public void SetParado(bool s)
    {
        parado = s;
        playerRig.velocity = Vector2.zero;
    }

    public bool GetParado()
    {
        return parado;
    }

    public bool GetAgachado()
    {
        return agachado;
    }

    public int GetVida()
    {
        return vida;
    }

    public void SetVida(int vida)
    {
        this.vida = vida;
    }

    /*public void SetEscondido(bool e)
    {
        escondido = e;
    }*/


    //------------------------------------- Inventario
    //---------- Itens

    public ScriptInventory GetInventory()
    {
        return invPlayer;
    }

    public void SetInventory(ScriptInventory inv)
    {

        {
            Debug.Log(invPlayer.inventario.Count + " : " + inv.inventario.Count);
            for (int a = 0; a < inv.inventario.Count; a++)
            {
                invPlayer.AdicionarItem(inv.inventario[a].item, inv.inventario[a].quantidade);
            }
        }
    }
    //Limpar o Inventario
    public void InventoryClear()
    {
        if (invPlayer.inventario.Count > 0)
        {
            for (int a = 0; a <= invPlayer.inventario.Count; a++)
            {
                invPlayer.inventario.RemoveAt(0);
            }
        }
    }

    public Item[] TodosItens()
    {
        Item[] itens = new Item[invPlayer.inventario.Count];
        for (int a = 0; a < invPlayer.inventario.Count; a++)
        {
            itens[a] = invPlayer.inventario[a].item;
        }
        if (itens != null)
        {
            return itens;
        }
        return null;
    }
}
