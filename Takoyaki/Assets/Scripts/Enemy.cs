using UnityEngine;
using System.Collections;

public class Enemy : Token 
{	
	//生存数
	public static int Count = 0;
	// Use this for initialization
	void Start () 
	{
		//生存数を増やす
		Count++;
		
		//set size
		SetSize(SpriteWidth / 2, SpriteHeight / 2);
		
		//random direction
		float dir = Random.Range(0,359);
		
		//verocity is 2
		float spd = 2;
		SetVelocity(dir,spd);
	}
	
	//renew
	void Update()
	{
		
		//get lower left points
		Vector2 min = GetWorldMin();
		//get upper right points
		Vector2 max = GetWorldMax();
		
		if (X < min.x || max.x < X)
		{
			//reverse verocity
			VX *= -1;
			//move in screen
			ClampScreen();
		}
		if (Y < min.y || max.y < Y)
		{
			VY*=-1;
			ClampScreen();
		}
	}
	
	public void OnMouseDown()
	{
		//生存数減らす
		Count--;
		
		
		//create Partice
		for (int i = 0; i < 32; i++)
		{
			Particle.Add(X,Y);
		}
		
		
		//destroy
		DestroyObj();
	}
	
	
}
