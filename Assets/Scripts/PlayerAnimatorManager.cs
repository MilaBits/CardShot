using UnityEngine;


public class PlayerAnimatorManager : MonoBehaviour {
    private Animator animator;
    
    
    [SerializeField]
    private float directionDampTime = 0.25f;

    private void Start() {
        animator = GetComponent<Animator>();
        if (!animator) {
            Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
        }
    }
    
    void Update()
    {
        if (!animator)
        {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", h * h + v * v);
        animator.SetFloat("Direction", h, directionDampTime, Time.deltaTime);
    }
}