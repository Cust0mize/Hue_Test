using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;
using Spine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class EndAimPlayerAnimation : BasePlayerAnimation {
        public override void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        ) {
            animationState.AddEmptyAnimation(AIM_ANIMATION_TRACK_INDEX, 0.5f, 0.1f);
            TrackEntry trackIdleAim = animationState.AddEmptyAnimation(AIM_ANIMATION_TRACK_INDEX, 0.5f, 0.1f);
            trackIdleAim.MixBlend = MixBlend.First;
        }
    }
}