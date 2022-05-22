using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGroup : MonoBehaviour
{
    ToggleBase[] _ToggleList;

    public void Init()
    {
        this._ToggleList = this.gameObject.GetComponentsInChildren<ToggleBase>();
        // トグルの初期化
        foreach(var toggle in this._ToggleList)
        {
            toggle.InitToggle(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggle(ToggleBase target)
    {
        // ターゲット以外のトグルをオフにする
        foreach(var toggle in this._ToggleList)
        {
            if(toggle == target)
                continue;

            toggle.Init = false;
        }
    }

    // 全てのトグルをオフにする
    public void OffAllToggle()
    {
        // ターゲット以外のトグルをオフにする
        foreach(var toggle in this._ToggleList)
            toggle.Init = false;
    }
}
