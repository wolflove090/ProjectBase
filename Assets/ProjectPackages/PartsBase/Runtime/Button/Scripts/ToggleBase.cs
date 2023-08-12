using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ToggleBase : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    ToggleGroup _Group;

    [NonSerialized]
    public System.Action<bool> OnChange;
    bool _IsOn;
    // 外部からトグル変更用
    public bool IsOn
    {
        set
        {
            this._IsOn = value;
            this._Fade(this._IsOn);
        }
        get
        {
            return this._IsOn;
        }
    }
    // 初期化用（アニメーションしない）
    public bool Init
    {
        set
        {
            this._IsOn = value;
            this._Fade(this._IsOn, 0);
        }
    }

    [SerializeField]
    CanvasGroup _OnCanvas;

    // 初期化
    public void InitToggle(ToggleGroup group)
    {
        if(group == null)
            throw new Exception("Groupを設定してください");

        this._Group = group;
    }

    protected void Start()
    {
        this._Fade(this._IsOn, 0);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
    }

    public void OnPointerDown(PointerEventData e)
    {
    }

    public void OnPointerUp(PointerEventData e)
    {
        this._IsOn = !this._IsOn;
        Tween tween = this._Fade(this._IsOn); 

        tween.OnComplete( () => 
        {
            if (this.OnChange != null)
                this.OnChange(this._IsOn);
        });
    }

    protected Tween _Fade(bool isOn, float duration = 0.1f)
    {
        // Onの表示
        if(isOn)
        {
            // トグルの変更を送信
            if(this._Group != null)
                this._Group.OnToggle(this);
            return this._OnCanvas.DOFade(1f, duration);
        }
        // Offの表示
        else
            return this._OnCanvas.DOFade(0, duration);
    }
}
