using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class IdlePlayerAnimation : BasePlayerAnimation {
        public override void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        ) {
            AnimationReferenceAsset targetAnimation = animations[0];
            spineAnimationService.SetAnimationAndGetTrack(animationState, targetAnimation, MOVING_TRACK_INDEX, IDLE_ANIMATION_LOOP);
        }
    }
}