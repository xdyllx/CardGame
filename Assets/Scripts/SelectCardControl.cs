using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCardControl : MonoBehaviour
{
    public GameObject cardPrefeb;
    public GameObject cardPool;

    CardStore CardStore;
    List<GameObject> cards = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CardStore = GetComponent<CardStore>();
        CardStore.LoadCardData();
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard()
    {
        ClearCard();
        List<Card> cardList = CardStore.GetCardList();
        Debug.Log("cardList size" + cardList.Count);
        foreach(var card in cardList)
        {
            GameObject newCard = GameObject.Instantiate(cardPrefeb, cardPool.transform);
            CardDsiplay cardDsiplay = newCard.GetComponent<CardDsiplay>();
            cardDsiplay.card = card;
            Sprite cardSprite = CardStore.GetCardSprite(card.Id);
            cardDsiplay.ShowCard(cardSprite);
            cards.Add(newCard);
        }
    }

    public void ClearCard()
    {
        foreach(var card in cards)
        {
            Destroy(card);
        }
        cards.Clear();
    }
}
