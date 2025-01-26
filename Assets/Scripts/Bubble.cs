using UnityEngine;

public class Bubble : MonoBehaviour
{

    public GameObject particelBurst;
    public Color myColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 20f);
    }

    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider collider){
       GetComponent<Rigidbody>().AddForce(collider.gameObject.transform.forward * 0.08f);
    }

    void OnDestroy(){
        GameObject colorExplosion = Instantiate(particelBurst, transform.position, transform.rotation);
        colorExplosion.GetComponent<Explosion>().BubbleValues(transform.localScale.x,myColor);
        colorExplosion.name = "colorExplosion";
    }
}
