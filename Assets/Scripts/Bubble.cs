using UnityEngine;

public class Bubble : MonoBehaviour
{

    public GameObject particelBurst;
    public Color myColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isBubbleFree = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isBubbleFree)
            Destroy(gameObject, 20f);
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name.Contains("Bubble")){
            myColor = (myColor + collision.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.GetColor("_BaseColor"))/3f;
        }
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
