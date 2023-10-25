using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Link
{
    public interface ILink : IGameObject
    {
        public void LinkUp();
        public void LinkDown();
        public void LinkLeft();
        public void LinkRight();
        public void LinkTakeDamage();
        public void LinkUseItem();
        public String GetState();
        public int GetDirection();
        public int GetHealth();
        public void Update();
        public void SetLink(ILink link);
        public void SetState(String state);
        public void SetSprite(ISprite newSprite);
        public void Draw(SpriteBatch spriteBatch);
    }
}
