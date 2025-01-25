using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(ParticlesController))]
public class Explosion : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticlesController pc;

    public float BaseSize;

    private Color color;
    private float size;

    private bool Updated;

    public void Start()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
        pc = this.gameObject.GetComponent<ParticlesController>();

        Destroy(this.gameObject, 5);
    }

    public void Update()
    {
        if (!Updated && ps != null && pc != null) {
            UpdateParticles();
            Updated = true;
        }
    }


    public void BubbleValues(float size, Color color)
    {
        this.size = size;
        this.color = color;
    }

    private void UpdateParticles()
    {
        var psMain = ps.main;
        psMain.startColor = color;

        psMain.startSize = size * BaseSize * 2;

        pc.paintColor = color;

        pc.minRadius = size * BaseSize * 0.1f;
        pc.maxRadius = size * BaseSize * 0.8f;
    }
}
