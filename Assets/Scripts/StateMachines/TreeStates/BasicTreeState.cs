using Lean.Gui;
using UnityEngine;
public class BasicTreeState : TreeState
{
    [SerializeField] LeanToggle _leanToggle;
    public override void Ended()
    {

    }

    public override void InProgress()
    {

    }

    public override void ResetEverything()
    {
        _leanToggle.TurnOn();
    }
}
  