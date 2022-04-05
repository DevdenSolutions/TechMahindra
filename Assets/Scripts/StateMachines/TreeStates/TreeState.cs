using UnityEngine;

public abstract class TreeState : MonoBehaviour
{
    public abstract void ResetEverything();
    public abstract void InProgress();
    public abstract void Ended();
}