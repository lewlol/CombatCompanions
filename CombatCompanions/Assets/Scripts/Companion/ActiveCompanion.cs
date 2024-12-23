using UnityEngine;

public class ActiveCompanion : MonoBehaviour
{
    public Companion activeCompanion;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    
    private void Start()
    {
        GameEvent.gameEvent.onSetActiveCompanion += SetActiveCompanion;
        GameEvent.gameEvent.onStartedGame += SpawnCompanion;
    }
    public void SetActiveCompanion(Companion companion)
    {
        activeCompanion = companion;
    }

    public void SpawnCompanion()
    {
        if(activeCompanion != null)
        {
            Instantiate(activeCompanion, transform.position, Quaternion.identity);
        }
    }
}
