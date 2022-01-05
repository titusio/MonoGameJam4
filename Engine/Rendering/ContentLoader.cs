﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameJam4.Engine.Rendering
{
    public class ContentLoader
    {
        public Dictionary<string, Texture2D> Textures;
        
        public ContentLoader()
        {
            Textures = new Dictionary<string, Texture2D>();
        }

        public void LoadContend(ContentManager contentManager)
        {
            Textures.Add("Player", contentManager.Load<Texture2D>("Triangle"));
        }
    }
}