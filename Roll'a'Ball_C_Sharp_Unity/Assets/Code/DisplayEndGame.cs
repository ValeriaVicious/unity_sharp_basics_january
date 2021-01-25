using System.Drawing;
using UnityEngine.UI;


namespace GeekBrains
{
    public sealed class DisplayEndGame
    {
        #region Fields

        private Text _finishGameLabel;

        #endregion


        #region ClassLifeCycles

        public DisplayEndGame(Text finishGameText)
        {
            _finishGameLabel = finishGameText;
            _finishGameLabel.text = string.Empty;
        }

        #endregion


        #region Methods

        public void GameOver(object obj, CaughtPlayerEventArgs args)
        {
            _finishGameLabel.text = $"Game over! You were caught!";
        }

        #endregion
    }
}
