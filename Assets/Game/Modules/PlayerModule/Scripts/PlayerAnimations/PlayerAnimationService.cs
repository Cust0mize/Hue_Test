using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using System.Collections.Generic;
using Game.Modules.SpineModule;
using Spine.Unity;
using System.Linq;
using UnityEngine;
using System;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class PlayerAnimationService {
        private readonly Dictionary<Type, BasePlayerAnimation> _basePlayerAnimations;

        public PlayerAnimationService(BasePlayerAnimation[] basePlayerAnimations) {
            _basePlayerAnimations = basePlayerAnimations.ToDictionary(x => x.GetType());
        }

        public void PlayAnimation<T>(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection,
        params AnimationReferenceAsset[] animation
        ) where T : BasePlayerAnimation {
            _basePlayerAnimations[typeof(T)].PlayAnimation(playerMovementSettings, spineAnimationService, animation, animationState, parentTransform, isLeftDirection);
        }

        public BasePlayerAnimation GetAnimation<T>() where T : BasePlayerAnimation {
            return _basePlayerAnimations[typeof(T)];
        }
    }
}