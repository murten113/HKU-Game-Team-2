using System;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    void Awake() => total++;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("mainPlayer"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}

