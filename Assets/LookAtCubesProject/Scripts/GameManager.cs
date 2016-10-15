using UnityEngine;
using System.Collections;

namespace LookAtCubes
{
    public class GameManager : MonoBehaviour
    {

        #region Singleton pattern
        private static GameManager _instance;

        public static GameManager Instance
        {
            get { return _instance; }
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            _cubeSpawner = GetComponent<CubeSpawner>();
        }
        #endregion

        CubeSpawner _cubeSpawner;

        [SerializeField]
        float _startingTimeInterval;
        [SerializeField]
        float _timeDecreasingGradation;
        [SerializeField]
        float _minTimeInterval;

        void Start()
        {
            StartGame();
        }

        void StartGame()
        {
            _cubeSpawner.LoadCubePool();

            StartCoroutine(SpawnCubesRandomlyWithDecreasingTimeIntervals());
        }

        void LateUpdate()
        {
            GvrViewer.Instance.UpdateState();
            if (GvrViewer.Instance.BackButtonPressed)
            {
                Application.Quit();
            }
        }

        IEnumerator SpawnCubesRandomlyWithDecreasingTimeIntervals()
        {
            float time = _startingTimeInterval;

            while (true)
            {
                Vector3 direction = Random.onUnitSphere;
                direction.y = Mathf.Clamp(direction.y, 0.2f, 1f);
                float distance = 2 * Random.value + 1.5f;
                Vector3 randomPosition = direction * distance;

                _cubeSpawner.SpawnRandomCube(randomPosition);

                if (time > _minTimeInterval)
                    time -= _timeDecreasingGradation;

                yield return new WaitForSeconds(time);
                
            }
        }


    }
}