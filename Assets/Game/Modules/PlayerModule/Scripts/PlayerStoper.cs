using UnityEngine;

namespace Game.Modules.PlayerModule.Scripts {
    public class PlayerStoper : MonoBehaviour {
        [SerializeField] private Transform _playerTarget;
        private const float MIN_DISTANCE_TO_STOP = 3.5f;

        private void Update() {
            if (Vector2.Distance(_playerTarget.position, transform.position) < MIN_DISTANCE_TO_STOP) {
                Time.timeScale = 0;
            }

            if (Input.GetKey(KeyCode.Space)) {
                Time.timeScale = 1;
            }
        }
    }
}