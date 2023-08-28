using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject playerObject;
    private float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirecton = (playerObject.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirecton * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
