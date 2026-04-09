using UnityEngine;
using Model;
using ViewModel;

public class RootFactory<M, VM, V> : MonoBehaviour where M : GridObject, new() where VM : GridObjectVM, new() where V : DefaultGridObjectV
{
    [SerializeField] private GridObjectRoot<M, VM, V> _rootPrefab;

    public GridObjectRoot<M, VM, V> Create()
    {
        return Instantiate(_rootPrefab);
    }
}