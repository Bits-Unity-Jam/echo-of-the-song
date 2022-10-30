using System;
using UnityEngine;

public class TaskCollection : MonoBehaviour
{
    public event Action AllCompleted;

    public event Action<int> TaskSetuped;
    
    [SerializeField] private int _taskAmount;
    private int _currentTasks;
    
    private void Start()
    {
        _currentTasks = _taskAmount;
        TaskSetuped?.Invoke(_taskAmount);
    }

    public void Completed(int getItemAmount)
    {
        _currentTasks -= getItemAmount;
        if (_currentTasks <= 0)
        {
            AllCompleted?.Invoke();
        }
    }
}
