using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.LinkSword
{
	public interface ILinkSword : IGameObject
	{
		public void SwingSword(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
	}
}

