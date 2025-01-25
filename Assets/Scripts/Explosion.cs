using UnityEngine;

[RequireComponent (typeof(ParticleSystem))]
[RequireComponent (typeof(ParticlesController))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticlesController pc;

    public float BaseSize;

    public void Start()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
        pc = this.gameObject.GetComponent<ParticlesController>();

        BubbleValues(Random.value, new Color(Random.value, Random.value, Random.value));

        Debug.Log("Destroy init");
        Destroy(this.gameObject, 5);
    }

    public void BubbleValues(float size, Color color)
    {
        var psMain = ps.main;
        psMain.startColor = color;

        psMain.startSize = size * BaseSize * 2;

        pc.paintColor = color;

        pc.minRadius = size * BaseSize * 0.1f;
        pc.maxRadius = size * BaseSize * 0.8f;
    }
}
