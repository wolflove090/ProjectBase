using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanuki.Animation
{
    public static class AnimationExtensions
    {
        public static bool Play(this UnityEngine.Animation player, string animation, System.Action onComplete)
        {
            Debug.Log("アニメーション");
            onComplete?.Invoke();
            return player.Play(animation);
        }
    }
}
