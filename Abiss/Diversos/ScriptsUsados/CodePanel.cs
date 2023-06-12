using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodePanel : MonoBehaviour {

	[SerializeField]
	Text codeText;
	string codeTextValue ;
	ArmarioComSenha armario;
	public Animator animArmario;
	public GameObject puzzle, mensagem;
	public TextMeshProUGUI texto;
	public bool abriu; 
	Player player;

	public string senha; // aqui coloca a senha na qual a porta ou cadeado será aberto
	
	void Start()
    {
		codeTextValue = "";

		armario = FindObjectOfType<ArmarioComSenha>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}



	void Update () 
	{
		
		Senha();
	}

	public void Senha()
    {
		codeText.text = codeTextValue;
		if (codeTextValue.Length >= 5) 
		{
			codeTextValue = ""; //escreveu mais q 5 digitos, os numeros são apagados
			SalvarInformacoes.EscreverLinha("Errou a senha do armario na sala 8");

			Debug.Log("Senha Incorreta");
		}
			
		
	}

	public void BotaoConfirmar()
    {

		if (codeTextValue == (senha))
		{
			abriu = true;
			Debug.Log("Armario abril");
			SalvarInformacoes.EscreverLinha("Acertou a senha do armario da sala 8");

			animArmario.SetBool("Abrir", true);
			armario.painel.SetActive(false);
			armario.DropaItem();
			armario.podeInteragir = false;
			texto.text = "Chave Coletada";
			
		}

		if (codeTextValue.Length >= 5) //aqui limita o tamanho da senha ate 5 digitos
			codeTextValue = "";
	}

	public void ZeraSenha()
    {
		codeTextValue = "";
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

	

}
