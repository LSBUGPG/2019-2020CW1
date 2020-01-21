using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Dictionary<string, GameObject> potion;
    public List<GameObject> ingredients = new List<GameObject>();
    public List<string> namesOfIngredients = new List<string>();
    public GameObject[] ComplexIngredients;
    public GameObject[] placeholders;

    public List<GameObject> currentIngredients;
    int placeholderIndex = 7;

    
    void Start()
    {
        potion = new Dictionary<string, GameObject>
        {
            { "Rat Redcandle", ComplexIngredients[0] },
            { "Arcanefluid Pigeonleg Redcandle", ComplexIngredients[1] },
            { "Dryherbs Redcandle", ComplexIngredients[2] },
            { "Arcanefluid Ratbones Redcandle", ComplexIngredients[3] },
            { "Ash Redcandle Redpotion", ComplexIngredients[4] },
            { "Arcanefluid Dryherbs Redcandle", ComplexIngredients[5] },
            { "Arcanefluid Rat", ComplexIngredients[6] },
            { "Arcanefluid Freshherbs", ComplexIngredients[7] },
            { "Blackcandle Blessing Curse", ComplexIngredients[8] }
        };
    }
        
    public void AddIngredient(GameObject obj)
    {
        ingredients.Add(obj);
        namesOfIngredients.Add(obj.tag);
    }

    public void SubmitIngredients()
    {
        namesOfIngredients.Sort();
        string ingredientsName = "";
        foreach (var item in namesOfIngredients)
        {
            ingredientsName += item + " ";
        }

        ingredientsName = ingredientsName.Trim();                                                                                               //Remove any white space at end
        print(ingredientsName);
       
        if (potion.ContainsKey(ingredientsName))
        {
            print(potion[ingredientsName]);

            if (currentIngredients.Contains(potion[ingredientsName]) == false)
            {
                Instantiate(potion[ingredientsName], placeholders[placeholderIndex].transform.position, Quaternion.identity);
                placeholderIndex += 1;
                currentIngredients.Add(potion[ingredientsName]);
            }
           
        }
		      
        foreach (var item in ingredients)                                                                                                       //Remove ingredients from drop zones
        {
            Destroy(item);
        }
       
        ingredients = new List<GameObject>();                                                                                                   //Reset list items
        namesOfIngredients = new List<string>();
    }
}
