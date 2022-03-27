using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStore : MonoBehaviour
{

    public TextAsset cardData;
    public List<Card> cardList = new List<Card>();

    private Dictionary<int, Sprite> spriteMap = new Dictionary<int, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardData()
    {
        // load image
        Sprite[] sps = Resources.LoadAll<Sprite>("");

        for (int i = 0; i < sps.Length;++i) {
            string imageName = sps[i].name;
            int imageId = int.Parse(imageName);
            spriteMap[imageId] = sps[i];
            Debug.Log("imageName:" + imageName + ", imageId:" + imageId);
        }

        string[] dataRow = cardData.text.Split('\n');
        foreach(var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "1") // move card
            {
                MoveCard moveCard = new MoveCard(int.Parse(rowArray[1]), "", int.Parse(rowArray[2]), int.Parse(rowArray[3]), int.Parse(rowArray[4]));
                cardList.Add(moveCard);
            }
            else if (rowArray[0] == "2") // recover card
            {
                RecoverCard recoverCard = new RecoverCard(int.Parse(rowArray[1]), "", int.Parse(rowArray[2]), int.Parse(rowArray[3]));
                cardList.Add(recoverCard);
            }
            else if (rowArray[0] == "3") // defend card
            {
                DefendCard defendCard = new DefendCard(int.Parse(rowArray[1]), "", int.Parse(rowArray[2]), int.Parse(rowArray[3]));
                cardList.Add(defendCard);
            }
            else if (rowArray[0] == "4")  // attack card
            {
                HashSet<int> attackRange = new HashSet<int>();
                foreach(var num in rowArray[4].Split(';')) {
                    attackRange.Add(int.Parse(num));
                }
                AttackCard attackCard = new AttackCard(int.Parse(rowArray[1]), "", int.Parse(rowArray[2]), int.Parse(rowArray[3]), attackRange);
                cardList.Add(attackCard);
            }
        }

        foreach(var card in cardList)
        {
            Debug.Log(card.GetInfo());
        }
    }

    

    public List<Card> GetCardList()
    {
        return cardList;
    }

    public Sprite GetCardSprite(int cardId)
    {
        Debug.Log("GetCardSprite, cardId:" + cardId + ", map size:" + spriteMap.Count + ", spriteMap[cardId]:" + spriteMap[cardId].name);
        return spriteMap[cardId];
    }
}
