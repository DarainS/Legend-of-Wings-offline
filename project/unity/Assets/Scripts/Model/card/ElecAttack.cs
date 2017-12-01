using System;
using Model;

namespace Model
{
	public class ElecAttack : Card
	{
		public ElecAttack ()
		{
			
		}



		public override void playEffect()
		{
			Character character=new Character();
            character.BeforeDamage.AddFirst(this);
		}
	}
}

