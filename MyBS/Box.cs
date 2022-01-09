using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MyBS
{
    public class Box
    {
        public string Name { get; private set; }
        public int HitPoints { get; private set; }

        public Box(string name, int hitPoints)
        {
            Name = name;
            HitPoints = hitPoints;
        }

        public void ApplyDamage(int amountOfDamage)
        {
            HitPoints -= amountOfDamage;
        }

        public Box Clone()
        {
            return new Box(Name, HitPoints);
        }
    } 
} 
namespace MyBS
{ 
    public class TestBox
	{
        void TestPrototypePattern()
		{
            Box TestBox = new Box("test", 100);
		}
       
	}
}
