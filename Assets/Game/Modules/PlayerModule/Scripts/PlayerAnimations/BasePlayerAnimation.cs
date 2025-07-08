using Game.Modules.PlayerModule.Scripts.SoConfigs;
using AnimationState = Spine.AnimationState;
using Game.Modules.SpineModule;
using Spine.Unity;
using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts.PlayerAnimations {
    public abstract class BasePlayerAnimation {
        protected const int AIM_ANIMATION_TRACK_INDEX = 2;
        protected const int AIM_IDLE_TRACK_INDEX = 1;
        protected const int MOVING_TRACK_INDEX = 0;
        protected const float SUBTRAHEND_ON_REVERSE = 1f;
        protected const float DEFAULT_RUN_MIX = 0.5f;
        protected const bool IDLE_ANIMATION_LOOP = true;
        protected const bool MOVING_ANIMATION_LOOP = true;

        public abstract void PlayAnimation(
        PlayerMovementSettings playerMovementSettings,
        SpineAnimationService spineAnimationService,
        AnimationReferenceAsset[] animations,
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection
        );

        protected float GetAnimationTrackTime(
        AnimationState animationState,
        Transform parentTransform,
        bool isLeftDirection,
        float frequence
        ) {
            float animationEnd = animationState.GetCurrent(MOVING_TRACK_INDEX).AnimationEnd;
            float frequenceX = parentTransform.position.x * frequence;
            float amplitude = (frequenceX - Mathf.Floor(frequenceX));

            if (isLeftDirection) {
                amplitude = SUBTRAHEND_ON_REVERSE - amplitude;
            }

            float trackTime = animationEnd * amplitude;
            return trackTime;
        }
    }
}