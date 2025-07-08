using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts.SoConfigs {
    [CreateAssetMenu(fileName = "PlayerMovementSettings", menuName = PlayerConstant.SO_PATH + "PlayerMovementSettings")]
    public class PlayerMovementSettings : ScriptableObject {
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float RunThreshold { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float Deceleration { get; private set; }
        [field: SerializeField] public float TargetOnDeceleration { get; private set; }
        [field: SerializeField] public float MinAccelerationDistance { get; private set; }
        [field: SerializeField] public float SpeedToMovingAnimation { get; private set; }
        [field: SerializeField] public float RunAnimationFrequency { get; private set; }
        [field: SerializeField] public float WalkAnimationFrequency { get; private set; }
    }
}