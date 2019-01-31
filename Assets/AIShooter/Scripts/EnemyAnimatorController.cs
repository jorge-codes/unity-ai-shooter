using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class EnemyAnimatorController : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    protected float _newMagnitude;
    protected float _oldMagnitude;

    protected AIAgent _agent;

    private void Start()
    {
        _newMagnitude = _oldMagnitude = 0f;
        if (_animator == null)
        {
            Debug.LogError("Animator Component missing");
        }

        _agent = GetComponent<AIAgent>();
        if (_agent == null)
        {
            Debug.LogError("AIAgent Component missing");
        }
    }

    private void FixedUpdate()
    {
        if (_animator == null) return;
        
        _newMagnitude = _agent.Velocity.magnitude;
        if (_newMagnitude != _oldMagnitude)
        {
            bool walk = _newMagnitude == 0f ? false : true;
            _animator.SetBool("walk", walk);
        }
        _oldMagnitude = _newMagnitude;
    }
}
