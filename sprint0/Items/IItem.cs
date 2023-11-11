using System;
using Microsoft.Xna.Framework.Graphics;
using static sprint0.Globals;

namespace sprint0
{
	public interface IItem : IGameObject
	{
		public void Use(Direction linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
	}
}

