﻿namespace Humper
{
	using Base;

	public interface ICollision
	{
		/// <summary>
		/// Gets the box that is moving and collides with an other one.
		/// </summary>
		/// <value>The box.</value>
		Box Box { get; }

		/// <summary>
		/// Gets the other box than being collided by the moving box.
		/// </summary>
		/// <value>The other.</value>
		Box Other { get; }

		/// <summary>
		/// Gets the origin of the box move.
		/// </summary>
		/// <value>The origin.</value>
		RectangleF Origin { get; }

		/// <summary>
		/// Gets the goal position of the box move.
		/// </summary>
		/// <value>The goal.</value>
		RectangleF Goal { get; }

		/// <summary>
		/// Gets information about the impact point.
		/// </summary>
		/// <value>The hit.</value>
		Hit Hit { get; }
	}
}

