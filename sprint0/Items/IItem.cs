using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0
{
	public interface IItem : IGameObject
	{
		public void Use(int linkDirection, int linkXPos, int linkYPos, int linkHeight, int linkWidth);
	}
}

