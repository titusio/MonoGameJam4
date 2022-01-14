﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameJam4.Engine.Entities;
using MonoGameJam4.Engine.Interfaces;
using MonoGameJam4.Engine.WorldSpace;

namespace MonoGameJam4.Engine.Rendering.ParticleEngine
{
    /// <summary>
    /// particle Object
    /// based on http://rbwhitaker.wikidot.com/2d-particle-engine-1
    /// </summary>
    public class ParticleSystem : GameObject, IRenderCall
    {
        private readonly Random _random;
        private List<Particle> _particles;
        private List<Texture2D> _textures;
        private readonly Color _color;

        public ParticleSystem(GameCenter gameCenter, Transform transform, string name, List<Texture2D> textures, Color color) : base(
            gameCenter, transform, name)
        {
            _textures = textures;
            _particles = new List<Particle>();
            _random = new Random();
            _color = color;
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = _textures[_random.Next(_textures.Count)];
            Vector2 position = Transform.Position;
            Vector2 velocity = new Vector2(
                1f * (float) (_random.NextDouble() * 2 - 1),
                1f * (float) (_random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float) (_random.NextDouble() * 2 - 1);
            float size = .2f;
            int ttl = 20 + _random.Next(40);

            return new Particle(new Transform(position, new Vector2(size), angle), texture, velocity, angularVelocity, _color, 20);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            int total = 10;

            for (int i = 0; i < total; i++)
            {
                _particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < _particles.Count; particle++)
            {
                _particles[particle].Update();
                if (_particles[particle].LiveTime <= 0)
                {
                    _particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Render(SpriteBatch spriteBatch, Camera camera, Window gameWindow)
        {
            foreach (Particle t in _particles)
            {
                t.Render(spriteBatch, camera, gameWindow);
            }
        }
    }
}