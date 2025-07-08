using UnityEngine;
using Spine;

namespace Game.Modules.PlayerModule.Scripts.SoConfigs {
    [CreateAssetMenu(fileName = "IdleAimSO", menuName = PlayerConstant.SO_PATH + "IdleAimSO")]
    public class IdleAimSO : ScriptableObject {
        [Header("Idle settings")]
        [field: SerializeField] public MixBlend IdleTrackMixBlend = MixBlend.Replace;

        [field: SerializeField] public float IdleAttachmentThreshold = 0;
        [field: SerializeField] public float IdleMixDuration = 0;
        [field: SerializeField] public float IdleAlpha = 0.1f;

        [Header("Aim Settings")]
        [field: SerializeField] public MixBlend AimTrackMixBlend = MixBlend.Replace;

        [field: SerializeField] public float AimAttachmentThreshold = 0;
        [field: SerializeField] public float AimMixDuration = 0;
        [field: SerializeField] public float AimAlpha = 0.1f;
    }
}