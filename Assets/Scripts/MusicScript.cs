using UnityEngine;

public class MusicScript : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Pobierz komponent Audio Source
        audioSource = GetComponent<AudioSource>();

        // Rozpocznij odtwarzanie muzyki
        audioSource.Play();
    }
}