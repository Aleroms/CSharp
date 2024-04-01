namespace CookiesCookbook
{
    public enum IngredientType
    {
        WHEAT, COCONUT, BUTTER, CHOCOLATE,
        SUGAR, CARDAMOM, CINNAMON, COCOA
    }
    public static class IdToItem
    {
        public static Ingredient GetIngredient(IngredientType id)
        {
            
            switch(id)
            {
                case IngredientType.WHEAT:
                    return new Wheat();
                case IngredientType.COCONUT:
                    return new Coconut();
                case IngredientType.BUTTER:
                    return new Butter();
                case IngredientType.SUGAR:
                    return new Sugar();
                case IngredientType.CHOCOLATE:
                    return new Chocolate();
                case IngredientType.CARDAMOM:
                    return new Cardamom();
                case IngredientType.CINNAMON:
                    return new Cinnamon();
                case IngredientType.COCOA:
                    return new Cocoa();
            }

            return new Ingredient();
        }
    }
    public class Ingredient
    {
        public IngredientType Id { get; init; }
        public string Name { get; init; }

        public Ingredient()
        {
            Id = 0;
            Name = "defalt";
        }
        public Ingredient(IngredientType id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString() => "Ingredient";
        
    }
    public interface IRecipePreparation
    {
        string Prepare();
    }

    public class Wheat : Ingredient, IRecipePreparation
    {
        public Wheat() : base(IngredientType.WHEAT, "Wheat flour")
        {
        }
        public string Prepare() => "Sieve. Add to other ingredients";
        public override string ToString() => Name;
    }
    public class Coconut : Ingredient, IRecipePreparation
    {
        public Coconut() : base(IngredientType.COCONUT, "Coconut flour")
        {
        }
        public string Prepare() => "Sieve. Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Butter : Ingredient, IRecipePreparation
    {
        public Butter() : base(IngredientType.BUTTER, "Butter")
        {
        }
        public string Prepare() => "Melt on low heat. Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Chocolate : Ingredient, IRecipePreparation
    {
        public Chocolate() : base(IngredientType.CHOCOLATE, "Chocolate")
        {
        }
        public string Prepare() => "Melt in a water bath. Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Sugar : Ingredient, IRecipePreparation
    {
        public Sugar() : base(IngredientType.SUGAR, "Sugar")
        {
        }

        public string Prepare() => "Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Cardamom : Ingredient, IRecipePreparation
    {
        public Cardamom() : base(IngredientType.CARDAMOM, "Cardamom")
        {
        }

        public string Prepare() => "Take half a teaspoon. Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Cinnamon : Ingredient, IRecipePreparation
    {
        public Cinnamon() : base(IngredientType.CINNAMON, "Cinamon")
        {
        }

        public string Prepare() => "Take half a teaspoon. Add to other ingredients.";
        public override string ToString() => Name;
    }
    public class Cocoa : Ingredient, IRecipePreparation
    {
        public Cocoa() : base(IngredientType.COCOA, "Cocoa powder")
        {
        }

        public string Prepare() => "Add to other ingredients";
        public override string ToString() => Name;
    }

}