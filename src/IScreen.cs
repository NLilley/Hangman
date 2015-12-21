using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    /// <summary>
    /// The IScreen interface is intended to allow the different screens of the game
    /// to be controlled in a common way.
    /// </summary>
    interface IScreen
    {
        /// <summary>
        /// This function should be implemeneted in a way which causes the full screen to be 
        /// shown to the user.
        /// </summary>
        void Show();

        /// <summary>
        /// This function should hide the full screen from the user.
        /// </summary>
        void Hide();

        /// <summary>
        /// This function should cause the entire screen to be reset to a clean state.
        /// In the case of the gamescreen for instance, this should reset the game back
        /// to the beginning.
        /// </summary>
        void Reset();

    }
}
