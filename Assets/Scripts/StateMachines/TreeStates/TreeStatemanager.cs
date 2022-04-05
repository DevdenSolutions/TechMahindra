using System.Collections.Generic;
using UnityEngine;

public class TreeStatemanager : MonoBehaviour
{
    #region singleton

    private static TreeStatemanager _instance;

    public static TreeStatemanager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    #endregion


    private TreeState _currentState;
    [SerializeField] List<TreeState> _treeStates;
    public int currentIndex = 0;
    [SerializeField] RealTreeStates TheCurrentTree;
    [SerializeField] Mode TheCurrentMode;


    #region InternalWorking
    public TreeState CurrentState
    {
        get => _currentState;

        set
        {
            if (_currentState != null)
            {
                _currentState.Ended();
            }

            _currentState = value;

            _currentState.ResetEverything();


        }
    }

    void StateEvent(int ID)
    {
        CurrentState = _treeStates[ID];
    }

    void SwitchState(int ID)
    {
        print("ID: " + ID);
        if (currentIndex != ID && ID < _treeStates.Count)
        {
            StateEvent(ID);
            currentIndex = ID;
            TheCurrentTree = (RealTreeStates)ID;
        }
        else
        {
            print("The index is not valid");
        }
    }

    private void Start()
    {
        StateEvent(0);
    }

    void SwitchStates(VirtualTreeStates virtualTreeStates)
    {
        string s = "";
        RealTreeStates rts = (RealTreeStates)0;
        if (virtualTreeStates > VirtualTreeStates.Mode)
        {
            switch (TheCurrentMode)
            {
                case Mode.Learning:
                    s = "L_" + virtualTreeStates.ToString();
                    rts = (RealTreeStates)System.Enum.Parse(typeof(RealTreeStates), s);
                    break;
                case Mode.Evaluation:
                    s = "E_" + virtualTreeStates.ToString();
                    rts = (RealTreeStates)System.Enum.Parse(typeof(RealTreeStates), s);
                    break;
            }
            print("The RTS: " + rts);
            SwitchState((int)rts);
        }
        else
        {
            SwitchState((int)virtualTreeStates);
        }

    }

    #endregion
    public void TheSwitching(int ID)
    {
        SwitchStates((VirtualTreeStates)ID);
    }
    public void TheSwitching(VirtualTreeStates virtualTreeStates)
    {
        SwitchStates(virtualTreeStates);
    }

    public RealTreeStates GetCurrentState()
    {
        return TheCurrentTree;
    }

    public Mode GetCurrentMode()
    {
        return TheCurrentMode;
    }

    public void SetMode(Mode mode)
    {
        TheCurrentMode = mode;
    }

}

public enum RealTreeStates
{
    Loading,
    Language,
    Login,
    Mode,
    L_Topic,
    E_Topic,
    L_Module1,
    E_Module1,
    L_Module2,
    E_Module2,
    L_Dismantle,
    E_Dismantle,
    L_Assemble,
    E_Assemble,
    L_RockMeasure,
    E_RockMeasure,
    L_FreeplayDegree,
    E_FreeplayDegree,
    L_FreeplayStarterRing,
    E_FreeplayStarterRing
}

public enum VirtualTreeStates
{
    Loading,
    Language,
    Login,
    Mode,
    Topic,
    Module1,
    Module2,
    Dismantle,
    Assemble,
    RockMeasure,
    FreeplayDegree,
    FreeplayStarterRing
}


public enum Mode
{
    Learning,
    Evaluation
}
