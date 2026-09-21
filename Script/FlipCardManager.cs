using UnityEngine;
using UnityEngine.UI;
using TMPro; // penting untuk TMP
using System.Collections.Generic;

public class FlipCardManager : MonoBehaviour
{
    public static FlipCardManager instance;

    public Transform cardGrid;   // drag CardGrid ke sini di Inspector
    public TMP_Text timerText;   // pakai TMP_Text, bukan Text
    public GameObject winPanel;
    public GameObject losePanel;

    [HideInInspector] public List<FlipCard> flippedCards = new List<FlipCard>();

    private float timeLeft = 30f; // 30 detik
    private int matchedPairs = 0;
    private int totalPairs = 4;
    private bool canFlip = true; // kontrol supaya nggak bisa flip lebih dari 2

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ShuffleCards();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Ceil(timeLeft);

            if (timeLeft <= 0)
            {
                GameOver(false);
            }
        }
    }

    public void StartTimer()
    {
        timeLeft = 30f; // reset timer
        Time.timeScale = 1f; // pastikan game jalan
    }

    public void CardFlipped(FlipCard card)
    {
        if (!canFlip) return; // kalau lagi nunggu reset, jangan flip

        flippedCards.Add(card);

        if (flippedCards.Count == 2)
        {
            canFlip = false; // stop dulu sampai dicek
            CheckMatch();
        }
    }

    void CheckMatch()
    {
        if (flippedCards[0].frontSprite == flippedCards[1].frontSprite)
        {
            matchedPairs++;
            flippedCards.Clear();
            canFlip = true;

            if (matchedPairs >= totalPairs)
            {
                GameOver(true);
            }
        }
        else
        {
            StartCoroutine(ResetCards());
        }
    }

    System.Collections.IEnumerator ResetCards()
    {
        yield return new WaitForSeconds(1f);

        foreach (FlipCard card in flippedCards)
        {
            card.ShowBack();
        }

        flippedCards.Clear();
        canFlip = true; // boleh flip lagi
    }

    void GameOver(bool win)
    {
        if (win)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }
        Time.timeScale = 0f; // freeze game
    }

    void ShuffleCards()
    {
        List<Transform> cards = new List<Transform>();

        foreach (Transform card in cardGrid)
        {
            cards.Add(card);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].SetSiblingIndex(i);
        }
    }
}
