using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace DinoCards
{
    class DiscardPile
    {
        private bool _accepting;
        private int _currentValid;

        private List<Texture2D> _possibleTextures;
        private List<SoundEffect> _sfx;

        private Vector2 _pos;
        private Rectangle _rect;

        private float _shuffleTime;
        private float _shuffleTimer;

        public DiscardPile(Vector2 position, List<Texture2D> textures, List<SoundEffect> sfx)
        {
            _possibleTextures = textures;
            _sfx = sfx;

            _pos = position;
            _rect = new Rectangle(_pos.ToPoint(), (textures[0].Bounds.Size.ToVector2() * 1.2f).ToPoint());
            _accepting = false;
            _currentValid = 0;

            _shuffleTimer = _shuffleTime = 6f;
        }

        public void Update(float deltaTime)
        {
            _shuffleTimer -= deltaTime;

            if (_shuffleTimer > 0)
            {
                if (!_accepting)
                    _currentValid = Game1.RNG.Next(_possibleTextures.Count);
            }
            else
            {
                _shuffleTimer = _shuffleTime;
                if (!_accepting)
                    _sfx[0].Play();
                _accepting = !_accepting;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(_possibleTextures[_currentValid], _rect, Color.White * 0.5f);
        }

    }
}
