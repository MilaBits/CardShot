using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class Blaster : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask hitMask;

    LineRenderer lineRenderer;

    private AudioSource audioSource;

    private MeshRenderer meshRenderer;
    private Color originalEmission;

    [SerializeField]
    private int magazineSize;

    [SerializeField]
    private int ammoCount;

    [SerializeField]
    private float ReloadTime;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.materials[1] = Instantiate(meshRenderer.materials[1]);
    }

    private void Update()
    {
        if (Input.GetButtonDown($"Shoot{player.ControlSuffix}"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (ammoCount <= 0) return;

        ammoCount--;

        Ray ray = new Ray(transform.parent.position, transform.forward);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500f, hitMask);

        StartCoroutine(ShowLine(0.1f));

        if (hit.collider != null)
        {
            lineRenderer.SetPositions(new Vector3[] {transform.position, hit.point});

            var health = hit.collider.GetComponentInParent<Health>();
            if (health) health.TakeDamage(damage);
        }

        if (ammoCount <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        float elapsedTime = 0;
        originalEmission = meshRenderer.materials[1].GetColor("_EmissionColor");
        meshRenderer.materials[1].color = Color.black;

        while (elapsedTime < ReloadTime - .7f)
        {
            meshRenderer.materials[1].SetColor("_EmissionColor",
                Color.Lerp(Color.black, Color.green, (elapsedTime / ReloadTime)));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Flash ready
        meshRenderer.materials[1].SetColor("_EmissionColor", Color.red);
        yield return new WaitForSeconds(.3f);
        meshRenderer.materials[1].SetColor("_EmissionColor", originalEmission);

        // Reset magazine
        ammoCount = magazineSize;
        yield return new WaitForEndOfFrame();
    }

    IEnumerator ShowLine(float duration)
    {
        lineRenderer.enabled = true;
        audioSource.enabled = true;

        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;
        audioSource.enabled = false;
    }
}