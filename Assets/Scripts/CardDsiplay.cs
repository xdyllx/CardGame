using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDsiplay : MonoBehaviour
{
    public Image backGroundImage;

    public Card card;

    CardStore cardStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard(Sprite sprite)
    {

        backGroundImage.sprite = sprite;
    }

    private void LoadResources() 
    {

    }
}
