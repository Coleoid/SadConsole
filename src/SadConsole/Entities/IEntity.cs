using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using SadConsole.Components;

namespace SadConsole.Entities
{
    /// <summary>
    /// For projects which use SadConsole and want to be able to write
    /// unit tests for objects which use SadConsole Entities.  Currently
    /// only complete enough to succeed.  Fuller solution would include
    /// the full public API, and require creating IConsole, too.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Triggered when the entity changes position.
        /// </summary>
        event EventHandler<Entity.EntityMovedEventArgs> Moved;

        /// <summary>
        /// Automatically forwards the <see cref="AnimatedConsole.AnimationStateChanged"/> event.
        /// </summary>
        event EventHandler<AnimatedConsole.AnimationStateChangedEventArgs> AnimationStateChanged;

        /// <summary>
        /// A friendly name of the game object.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The current animation.
        /// </summary>
        AnimatedConsole Animation { get; set; }

        /// <summary>
        /// Collection of animations associated with this game object.
        /// </summary>
        Dictionary<string, AnimatedConsole> Animations { get; }

        /// <summary>
        /// The position of the screen object.
        /// </summary>
        /// <remarks>From Console.  This position has no substance.</remarks>
        Point Position { get; set; }

        /// <summary>
        /// Offsets the position by this amount.
        /// </summary>
        Point PositionOffset { get; set; }

        /// <summary>
        /// A collection of components processed by this console.
        /// </summary>
        /// <remarks>From Console.</remarks>
        ObservableCollection<IConsoleComponent> Components { get; }

        /// <inheritdoc />
        void OnCalculateRenderPosition();

        /// <summary>
        /// Saves the <see cref="Entity"/> to a file.
        /// </summary>
        /// <param name="file">The destination file.</param>
        void Save(string file);
    }
}
