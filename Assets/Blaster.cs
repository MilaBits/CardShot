using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

public class Blaster : MonoBehaviour {
    [SerializeField, InlineEditor]
    private ControlsContainer controlsContainer;

    private PlayerInput playerInput;

    [SerializeField]
    private int damage;

    [SerializeField]
    private LayerMask hitMask;

    LineRenderer lineRenderer;

    private AudioSource audioSource;

    private void OnEnable() {
//        controlsContainer.Controls.Gameplay.Shoot.Enable();
//        controlsContainer.Controls.Gameplay.Shoot.performed += Shoot;
//        controlsContainer.Controls.Gameplay.Shoot.cancelled += Shoot;
    }

    private void OnDisable() {
//        controlsContainer.Controls.Gameplay.Shoot.Disable();
//        controlsContainer.Controls.Gameplay.Shoot.performed -= Shoot;
//        controlsContainer.Controls.Gameplay.Shoot.cancelled -= Shoot;
    }

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot(InputAction.CallbackContext context) {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        Physics.Raycast(ray, out hit, 500f);

        StartCoroutine(ShowLine(0.1f));

        if (hit.collider != null) {
            lineRenderer.SetPositions(new Vector3[] {transform.position, hit.point});
            if (hit.collider.gameObject.layer == hitMask)
                hit.collider.GetComponent<Health>().TakeDamage(damage);
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