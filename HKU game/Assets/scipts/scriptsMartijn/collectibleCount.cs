using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    public int count;


    void Start() => UpdateCount();

    void Awake()
    {
       text = GetComponent<TMPro.TMP_Text>();
    }

    void OnEnable() => collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"Collected: {count}";
    }
}
