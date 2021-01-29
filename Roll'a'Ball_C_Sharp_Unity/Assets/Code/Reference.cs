using UnityEngine;


namespace GeekBrains
{
    public class Reference
    {
        #region Fields

        private PlayerBall _playerBall;
        private Camera _mainCamera;

        #endregion


        #region Methods

        public PlayerBall PlayerBall
        {
            get
            {
                if(_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>(InteractiveObjects.PlayerTag);
                    _playerBall = Object.Instantiate(gameObject);
                }
                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if(_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

        #endregion
    }
}
