﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using IUpdateable = MonoGameJam4.Engine.Interfaces.IUpdateable;

namespace MonoGameJam4.Engine
{
    public class InputManagement : IUpdateable
    {
        private Dictionary<Keys, Key> _callbacks;

        public InputManagement()
        {
            _callbacks = new Dictionary<Keys, Key>();
        }

        public void Update(GameTime gameTime)
        {
        }
    }

    public class Key
    {
        private readonly Keys _key;
        private bool _isPressed;

        public event Action Invoked;

        public Key(Keys key)
        {
            _key = key;
        }

        private void Update(KeyboardState keyboardState)
        {
            bool state = keyboardState.IsKeyDown(_key);

            if (!_isPressed) Invoked?.Invoke();

            _isPressed = state;
        }
    }
}