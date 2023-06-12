using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodePanel1 : MonoBehaviour {

	[SerializeField]
	Text codeText;
	string codeTextValue ;
	PainelComSenha painel;
	public Animator animParacela;
	AudiosPequenos audiosPequenos;
	
	public bool abriu; 
	//Player player;
	// senha correta 286
	public string senha; // aqui coloca a senha na qual a porta ou cadeado será aberto
	
	void Start()
    {
		codeTextValue = "";

		painel = FindObjectOfType<PainelComSenha>();
		audiosPequenos = FindObjectOfType<AudiosPequenos>();
		
	}



	void Update () 
	{
		
		Senha();
	}

	public void Senha()
    {
		codeText.text = codeTextValue;
		if (codeTextValue.Length >= 4) 
		{
			codeTextValue = ""; //escreveu mais q 3 digitos, os numeros são apagados
			

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


			animParacela.SetBool("Ativado", true);
			painel.DesativaColisor();
			audiosPequenos.BipConfirma();




		}

		if (codeTextValue.Length >= 3) //aqui limita o tamanho da senha ate 3 digitos
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
