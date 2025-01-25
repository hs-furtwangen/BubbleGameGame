using UnityEngine;

public class Explosion : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Destroy init");
        Destroy(this.gameObject, 5);
    }
}
