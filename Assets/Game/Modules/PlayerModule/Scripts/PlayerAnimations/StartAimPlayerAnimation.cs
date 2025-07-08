using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using UnityEngine;
using Spine.Unity;
using Spine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class StartAimPlayerAnimation : BasePlayerAnimation {
        public override void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        ) {
            AnimationReferenceAsset targetAnimation = animations[0];
            TrackEntry aimTrack = spineAnimationService.SetAnimationAndGetTrack(animationState, targetAnimation, AIM_ANIMATION_TRACK_INDEX, IDLE_ANIMATION_LOOP);
            aimTrack.MixBlend = MixBlend.Replace;
            aimTrack.AttachmentThreshold = 1;
            aimTrack.MixDuration = 0.3f;
            aimTrack.Alpha = 1;
        }
    }
}