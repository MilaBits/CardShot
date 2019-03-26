using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class Blaster : MonoBehaviour {
    [SerializeField]
    private Player player;

    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask hitMask;

    LineRenderer lineRenderer;

    private AudioSource audioSource;

    private void Start() {
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (Input.GetButtonDown($"Shoot{player.ControlSuffix}")) {
            Shoot();
        }
    }

    public void Shoot() {
        Ray ray = new Ray(transform.parent.position, transform.forward);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500f, hitMask);

        StartCoroutine(ShowLine(0.1f));

        if (hit.collider != null) {
            lineRenderer.SetPositions(new Vector3[] {transform.position, hit.point});

            var health = hit.collider.GetComponentInParent<Health>();
            if (health) health.TakeDamage(damage);
        }
    }

    IEnumerator ShowLine(float duration) {
        lineRenderer.enabled = true;
        audioSource.enabled = true;

        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;
        audioSource.enabled = false;
    }
}