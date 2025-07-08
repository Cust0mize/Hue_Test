using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;
using Spine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class WalkingPlayerAnimation : BasePlayerAnimation {
        public override void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        ) {
            AnimationReferenceAsset targetAnimation = animations[0];
            TrackEntry walkAnimationTrack = spineAnimationService.SetAnimationAndGetTrack(animationState, targetAnimation, MOVING_TRACK_INDEX, MOVING_ANIMATION_LOOP);
            walkAnimationTrack.TrackTime = GetAnimationTrackTime(animationState, parentTransform, playerMovementSettings, playerMovementSettings.WalkAnimationFrequency);
        }
    }
}