using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private int minSpeed = 12;
    private int maxSpeed = 16;
    private int torqueRange = 10;
    private int xRangePos = 4;
    private int yRangePos = 2;
    private AudioSource targetAudio;

    public int scoreValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(GiveRandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(GiveRandomTorque(), ForceMode.Impulse);
        transform.position = GiveRandomPosition();
        targetAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GiveRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 GiveRandomTorque()
    {
        return new Vector3(Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange), Random.Range(-torqueRange, torqueRange));
    }

    private Vector3 GiveRandomPosition()
    {
        return new Vector3(Random.Range(-xRangePos, yRangePos), Random.Range(-xRangePos, yRangePos));
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Bad"))
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.badSound);
        }
        else
        {
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.goodSound);
        }

        
        Destroy(gameObject);        
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        GameManager.instance.UpdateScore(scoreValue);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            GameManager.instance.GameOver();
            AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.gameOverSound);

            GameObject[] goodObjects = GameObject.FindGameObjectsWithTag("Good");
            
            foreach (GameObject obj in goodObjects)
            {
                Destroy(obj);
            }
        }
    }

    public static Target instance
    {
        get; private set;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
