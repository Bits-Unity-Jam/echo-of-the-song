using Mechanics.Collectable;
using UnityEngine;

public class TaskPresentor : MonoBehaviour
{
    [SerializeField] private TaskCollection _taskCollection;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out CollectPresentor collectPresentor))
        {
            _taskCollection.Completed(collectPresentor.GetItemAmount());
        }
    }
}
