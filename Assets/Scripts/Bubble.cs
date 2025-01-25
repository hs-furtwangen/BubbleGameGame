using UnityEngine;

public class Bubble : MonoBehaviour
{

    public GameObject particelBurst;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        print("Blubb");
        GameObject colorExplosion = Instantiate(particelBurst, transform.position, transform.rotation);
        colorExplosion.name = "colorExplosion";
        Destroy(gameObject);
    }
}
