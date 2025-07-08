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
            animationState.AddEmptyAnimation(AIM_ANIMATION_TRACK_INDEX, 0.3f, 0);
            TrackEntry trackIdleAim = animationState.AddEmptyAnimation(AIM_IDLE_TRACK_INDEX, 0.3f, 0);
            trackIdleAim.MixBlend = MixBlend.First;
        }
    }
}