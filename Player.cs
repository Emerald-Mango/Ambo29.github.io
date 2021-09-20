using Godot;
using System;

public class Player : KinematicBody2D
{
	float speed = 200;
	float gravity = 10;
	float jumpSpeed = -500;
	Vector2 direction = new Vector2();
	AnimatedSprite change;
	public override void _Ready()
	{
		change = GetNode<AnimatedSprite>("AnimatedSprite");
	}



	public override void _PhysicsProcess(float delta)
	{
		
		direction.y += gravity;
		
		if (IsOnFloor())
		{
			direction.y = 0;
		}
		
		direction.x = (Input.GetActionStrength("d") - Input.GetActionStrength("a"));
		if (direction.x == -1)
		{
			change.FlipH = true;
		}
		if (direction.x == 1)
		{
			change.FlipH = false;
		} 
		direction.x *= speed;
		if (Input.IsActionJustPressed("w") && IsOnFloor())
		direction.y = jumpSpeed;
		
		
		direction = MoveAndSlide(direction, Vector2.Up);
		

	}


}
