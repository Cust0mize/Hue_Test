using AnimationState = Spine.AnimationState;
using Animation = Spine.Animation;
using UnityEngine;
using Spine.Unity;
using System;
using Spine;

namespace Game.Modules.SpineModule {
    public class SpineAnimationService : IDisposable {
        public event Action OnEndTime;

        public void AnimationInit(SkeletonAnimation skeletonAnimation) {
            skeletonAnimation.Initialize(false);
            skeletonAnimation.Skeleton.SetToSetupPose();
            skeletonAnimation.AnimationState.Apply(skeletonAnimation.Skeleton);
            skeletonAnimation.Skeleton.SetSkin("default");
        }

        public void RunAnimations(AnimationState animationState, bool isLoopEnd, params string[] animationNames) {
            animationState.SetAnimation(0, animationNames[0], false);
            bool isLoop = false;

            for (int i = 1; i < animationNames.Length; i++) {
                if (isLoopEnd) {
                    isLoop = i == animationNames.Length - 1;
                }

                animationState.AddAnimation(0, animationNames[i], isLoop, 0);
            }
        }
        
        public TrackEntry SetAnimationAndGetTrack(
        AnimationState animationState,
        Animation animation,
        int trackIndex,
        bool isLoop
        ) {
            return animationState.SetAnimation(trackIndex, animation, isLoop);
        }
        
        public void RunAnimation(AnimationState animationState, string animationName, bool isLoopEnd) {
            animationState.SetAnimation(0, animationName, isLoopEnd);
        }

        private float GetMaxTime(AnimationState animationState, int trackIndex = 0) {
            TrackEntry track = animationState.GetCurrent(trackIndex);
            return track != null ? track.AnimationEnd - track.AnimationStart : -1;
        }

        public void RewindToTime(float time, AnimationState animationState, int trackIndex = 0) {
            TrackEntry track = animationState.GetCurrent(trackIndex);

            if (track == null) {
                return;
            }

            track.TrackTime = Mathf.Clamp(time, 0, GetMaxTime(animationState, trackIndex));
        }

        public void RewindToStartFrame(AnimationState animationState, int trackIndex = 0) {
            TrackEntry track = animationState.GetCurrent(trackIndex);

            if (track == null) {
                return;
            }

            track.TrackTime = track.AnimationStart;
        }

        public void RewindToEndFrame(AnimationState animationState, int trackIndex = 0) {
            TrackEntry track = animationState.GetCurrent(trackIndex);

            if (track == null) {
                return;
            }

            track.TrackTime = track.AnimationEnd;
        }

        private void EndTime() {
            OnEndTime?.Invoke();
        }

        public void Dispose() {
            OnEndTime = null;
        }
    }
}