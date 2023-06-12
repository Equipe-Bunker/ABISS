using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DepositoItens : MonoBehaviour
{
	[Header("Editaveis")]
	[SerializeField] string textoExibido; 
	[SerializeField] float tempoCarregamento; // tempo em segundos para simular o carregamento
	[SerializeField] AnimationCurve curvaDeCarregamento; // curva de animação para controlar a velocidade do preenchimento
	[SerializeField] List<ItensDeposito> itensDeposito = new List<ItensDeposito>();

	[Header("Não Editaveis")]
	[SerializeField] ScriptInventory playerInv;
	[SerializeField] Image carregamentoUI;
	[SerializeField] GameObject depositoUI, slotPrefab, inventario, textSemItem, textUI;
	[SerializeField] Scrollbar scroll;
	//[SerializeField] float scrollVelocidade;
	//[SerializeField] int selecionado;
	[SerializeField] Color corSelecionado, corDeselecionado;

	int itemSelecionado;
	IEnumerator coroutineCarregamento;
	bool colliderPlayer;
	GameObject[] slots;

    void Start()
    {
		slots = new GameObject[0];
	}
    void Update()
    {
		if (colliderPlayer)
		{
			//Abrir Deposito
			if (!depositoUI.activeSelf && Input.GetKeyDown(KeyCode.E))
			{
				textUI.SetActive(false);
				carregamentoUI.gameObject.SetActive(true);
				StartCoroutine(coroutineCarregamento);
				itemSelecionado = 0;
			}
			// Mover para cima
			if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && itemSelecionado > 0)
			{
				itemSelecionado -= 1;
				UpdateSelection();
			}
			// Mover para baixo
			else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && itemSelecionado < slots.Length - 1)
			{
				itemSelecionado += 1;
				UpdateSelection();
			}
			// Coletar item selecionado
			else if (depositoUI.activeSelf && Input.GetKeyDown(KeyCode.E))
			{
				ColetarItem();
			}
		}
	}

	void UpdateSelection()
	{
		if(itemSelecionado >= slots.Length)
        {
			itemSelecionado = slots.Length - 1;
        }
		for (int i = 0; i < slots.Length; i++)
		{
			Image image = slots[i].transform.GetChild(2).GetComponent<Image>();
			if (i == itemSelecionado)
			{
				image.color = corSelecionado;
			}
			else
			{
				image.color = corDeselecionado;
			}
		}
		ScrollToSelectedItem();
	}

	private void ScrollToSelectedItem()
	{
		ScrollRect scrollRect = depositoUI.GetComponent<ScrollRect>();

		float itemHeight = slots[0].GetComponent<RectTransform>().rect.height;
		float viewportHeight = scrollRect.viewport.rect.height;
		float contentHeight = scrollRect.content.rect.height;
		float selectedItemIndex = itemSelecionado; // Índice do item selecionado

		// Calcular a posição correta do ScrollRect
		float scrollPosition = itemHeight * selectedItemIndex - viewportHeight / 2 + itemHeight / 2;
		float normalizedPosition = Mathf.Clamp(scrollPosition / (contentHeight - viewportHeight), 0f, 1f);

		// Verificar se o item selecionado está no topo da janela
		bool isSelectedItemAtTop = scrollPosition <= 0f;

		// Se o item selecionado não estiver no topo da janela, mova-o para o topo
		if (!isSelectedItemAtTop)
		{
			// Calcular a posição correta do item selecionado
			float selectedItemPosition = itemHeight * selectedItemIndex;

			// Atualizar a posição normalizada para que o ScrollRect role para a posição correta
			normalizedPosition = selectedItemPosition / (contentHeight - viewportHeight);
			normalizedPosition = Mathf.Clamp(normalizedPosition, 0f, 1f);
		}

		// Inverter a direção do ScrollRect
		normalizedPosition = 1f - normalizedPosition;

		// Suavizar a transição da posição do ScrollRect
		float currentVelocity = 0f;
		scrollRect.verticalNormalizedPosition = Mathf.SmoothDamp(scrollRect.verticalNormalizedPosition, normalizedPosition, ref currentVelocity, 0);

	}

	// Animação de carregamento
	IEnumerator Carregamento()
	{
		float timer = 0f;
		while (timer < tempoCarregamento)
		{
			timer += Time.deltaTime;
			float progress = timer / tempoCarregamento;
			float curveProgress = curvaDeCarregamento.Evaluate(progress); // usa a curva de animação para ajustar a velocidade do preenchimento
			SetProgress(curveProgress); // atualiza a barra de progresso
			yield return null;
		}
		SetProgress(1.0f); // garante que a barra de progresso chegue a 100%
	}

	// Animação de carregamento aqui ele de fato muda o sprite
	void SetProgress(float progress)
	{
		carregamentoUI.fillAmount = progress;
		if (progress == 1)
		{
			carregamentoUI.gameObject.SetActive(false);
			AbrirFecharDeposito(true);
		}
	}

	//Abre e fecha a janela
	void AbrirFecharDeposito(bool abre)
	{
		if (abre)
		{
			depositoUI.SetActive(true);
			CarregarItens();
		}
		else
		{
			textUI.SetActive(false);
			depositoUI.SetActive(false);
			carregamentoUI.gameObject.SetActive(false);
		}
	}

	//Carregar os itens na hud	
	void CarregarItens()
	{
		slots = new GameObject[itensDeposito.Count];
		if (slots.Length > 0)
		{
			textSemItem.SetActive(false);
			for (int a = 0; a < inventario.transform.childCount; a++)
			{
				Destroy(inventario.transform.GetChild(a).gameObject);
			}
			//Adiciona itens no inventario
			for (int a = 0; a < itensDeposito.Count; a++)
			{
				slots[a] = Instantiate(slotPrefab, inventario.transform);
				slots[a].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itensDeposito[a].item.nome;
				slots[a].transform.SetParent(inventario.transform);
				if (itensDeposito[a].item.imagem) { slots[a].transform.GetChild(1).GetComponent<Image>().sprite = itensDeposito[a].item.imagem; }
			}
			scroll.value = 1;
			UpdateSelection();
		}
        else
        {
			if (inventario.transform.childCount > 0)
			{
				for (int a = 0; a < inventario.transform.childCount; a++)
				{
					Destroy(inventario.transform.GetChild(a).gameObject);
				}
			}
			textSemItem.SetActive(true);
		}
	}
	
	//Coleta o item
	void ColetarItem()
	{
		if (itensDeposito.Count > 0)
		{
			playerInv.AdicionarItem(itensDeposito[itemSelecionado].item, itensDeposito[itemSelecionado].quantidade);
			itensDeposito.RemoveAt(itemSelecionado);
			CarregarItens();
		}
	}


	//Verifica se o jogador entrou no hitbox
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			coroutineCarregamento = Carregamento();
			textUI.SetActive(true);
			textUI.GetComponent<TextMeshProUGUI>().text = textoExibido;
			colliderPlayer = true;
		}
	}

	//Verifica se o jogador saiu do hitbox
	void OnTriggerExit2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			colliderPlayer = false;
			StopCoroutine(coroutineCarregamento);
			AbrirFecharDeposito(false);
		}
	}
}

//Lista dos itens que vao aparecer
[System.Serializable]
public class ItensDeposito
{
	public Item item;
	public int quantidade;
}