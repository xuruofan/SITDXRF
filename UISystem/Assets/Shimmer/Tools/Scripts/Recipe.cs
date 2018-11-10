using System;
using UnityEngine;

namespace Shimmer.Tools
{
	public enum IngredientUnit { Spoon, Cup, Bowl, Piece }

	// Custom serializable class
	[Serializable]
	public class Ingredient
	{
		public string name;
		public int amount = 1;
		public IngredientUnit unit;
		public void Cook()
		{
			// Can be an action
		}
	}

	[CreateAssetMenu(fileName = "NewRecipe", menuName = "Shimmer/Tools/Recipe")]
	public class Recipe : ScriptableObject
	{
		public Ingredient potionResult;
	}
}