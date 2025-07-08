using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;
using Spine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public class IdleAimPlayerAnimation : BasePlayerAnimation {
        private readonly IdleAimSO _idleAimSo;

        public IdleAimPlayerAnimation(IdleAimSO idleAimSo) {
            _idleAimSo = idleAimSo;
        }

        public override void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        ) {
            Debug.Log("Setting IdleAimPlayerAnimation");
            AnimationReferenceAsset idleAnimation = animations[0];
            AnimationReferenceAsset aimAnimation = animations[1];

            TrackEntry idleTrack = spineAnimationService.SetAnimationAndGetTrack(animationState, idleAnimation, AIM_ANIMATION_TRACK_INDEX, IDLE_ANIMATION_LOOP);
            idleTrack.AttachmentThreshold = _idleAimSo.IdleAttachmentThreshold;
            idleTrack.MixDuration = _idleAimSo.IdleMixDuration;
            idleTrack.MixBlend = _idleAimSo.IdleTrackMixBlend;
            idleTrack.Alpha = _idleAimSo.IdleAlpha;

            TrackEntry aimTrack = spineAnimationService.SetAnimationAndGetTrack(animationState, aimAnimation, AIM_IDLE_TRACK_INDEX, IDLE_ANIMATION_LOOP);
            aimTrack.MixBlend = _idleAimSo.AimTrackMixBlend;
            aimTrack.AttachmentThreshold = _idleAimSo.AimAttachmentThreshold;
            aimTrack.MixDuration = _idleAimSo.AimMixDuration;
            aimTrack.Alpha = _idleAimSo.AimAlpha;
        }
    }
}