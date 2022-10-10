using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 外部発火が必要なコントローラー
public class ChildController<VIEWMODEL, LINKER> : ControllerBase<VIEWMODEL>
    where VIEWMODEL : ViewModelBase
    where LINKER : LinkerBase
{
    bool _Init;
    protected LINKER _Linker;

    void Start()
    {
        Debug.Log("何もしない");
    }

    void Update()
    {
        if(!this._Init)
            return;

        this._OnUpdate();
    }

    public void ExternalStart(LINKER linker)
    {
        Debug.Log("外部スタート");
        this._Linker = linker;
        this._Init = true;
        this._OnStart();
    }

    // -------------------- 継承先で実装 -------------------- //

    // Start
    protected virtual void _OnStart()
    {

    }
}