using UnityEngine;

public class Blocker : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private BarrierHealth health;

    private float timer;

    public void Init(Material material, float time)
    {
        meshRenderer.material = material;
        timer = time;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}