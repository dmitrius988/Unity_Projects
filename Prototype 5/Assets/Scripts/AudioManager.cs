using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip badSound;
    [SerializeField] public AudioClip goodSound;
    [SerializeField] public AudioClip gameOverSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static AudioManager instance
    {
        get; private set;
    }
    private void Awake()
    {
        instance = this;
    }
}
