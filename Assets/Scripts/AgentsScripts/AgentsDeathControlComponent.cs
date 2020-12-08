using UnityEngine;

public class AgentsDeathControlComponent : MonoBehaviour
{
    [SerializeField] private StatsComponent statsComponent;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private AgentsAutoAttackComponent agentsAutoAttackComponent;
    private void Awake()
    {
        statsComponent.addOnHealthDecreaseListener(isHealthRunOutDie);
    }
    private void isHealthRunOutDie(float health)
    {
        if(health<= 0)
        {
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.isKinematic = true;
            Destroy(gameObject,0.8f);
            if(agentsAutoAttackComponent != null)
            {
                Destroy(agentsAutoAttackComponent);
            }
        }
    }
}
