using UnityEngine;
using UnityEngine.UI;

public class FlipCard : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    private Image image;
    private bool isFlipped = false;

    void Start()
    {
        image = GetComponent<Image>();
        ShowBack();
    }

    public void OnClick()
    {
        // Jangan flip kalau sudah terbuka atau sudah ada 2 kartu terbuka
        if (isFlipped || FlipCardManager.instance.flippedCards.Count >= 2)
            return;

        ShowFront();
        FlipCardManager.instance.CardFlipped(this);
    }

    public void ShowFront()
    {
        image.sprite = frontSprite;
        isFlipped = true;
    }

    public void ShowBack()
    {
        image.sprite = backSprite;
        isFlipped = false;
    }
}
