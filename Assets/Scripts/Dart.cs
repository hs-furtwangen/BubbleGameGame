using UnityEngine;

public class Dart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        Destroy(gameObject);
    }
}
