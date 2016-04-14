using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ObjectValueComparison
{
    /// <summary>
    /// This is a value type comparison between any two objects.  This works
    /// with nested objects and collections of nested objects and so forth.  The order of objects
    /// in any lists DO matter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="ignoreCase">Optional parameter for string comparisons</param>
    /// <returns></returns>
    public static bool AreEqual<T>(T x, T y, bool ignoreCase = true)
    {
        return PropertiesAreEqual(x, y, ignoreCase);
    }

    private static bool PropertiesAreEqual<T>(T x, T y, bool ignoreCase)
    {
        //check if x is null and y isn't null or the reverse
        if ((x == null && y != null) || (x != null && y == null))
        {
            return false;
        }
        else if (x == null && y == null) // check if xand y are both null
        {
            return true;
        }
        //Get the types associated with xand b
        Type xType = x.GetType();
        Type yType = y.GetType();

        if ((xType.IsPrimitive && yType.IsPrimitive) || (x is string && y is string)) //Easy case
        {
            return valueTest(x, y, ignoreCase);
        }

        var xProperties = xType.GetProperties();
        var yProperties = yType.GetProperties();

        for (var property = 0; property < xProperties.Count(); property++)
        {
            var xProp = xProperties[property];
            var yProp = yProperties[property];

            object xValue, yValue;
            var xIndexParam = xProp.GetIndexParameters().Count();
            var yIndexParam = yProp.GetIndexParameters().Count();
            //Check if we need to deal with Indexers
            if (xIndexParam > 0)
            {
                //create temporary variables to hold the results from iterating through the indexer
                List<object> xIndexer = new List<object>();
                List<object> yIndexer = new List<object>();
                for (int i = 0; i < xIndexParam; i++)
                {
                    xIndexer.Add(xProp.GetValue(x, new object[] { i }));
                    yIndexer.Add(yProp.GetValue(y, new object[] { i }));
                }
                xValue = xIndexer;
                yValue = yIndexer;
            }
            else
            {
                xValue = xProp.GetValue(x, null);
                yValue = yProp.GetValue(y, null);
            }
            

            var xElements = xValue as IList;
            var yElements = yValue as IList;

            //Checking to see what kind of values we have
            if (xElements != null)  //Checking if we have a Ilist
            {
                for (var element = 0; element < xElements.Count; element++)
                {
                    if (!PropertiesAreEqual(xElements[element], yElements[element], ignoreCase))
                    {
                        return false;
                    }
                }
            }
            else if (xValue == null && yValue == null)  //Continue with comparison if both values are null
            {
                continue;
            }
            else if (canBeCompared(xProp, yProp) || (xValue is string && yValue is string)) //Check to see if we have a primitive or value type
            {
                if (!valueTest(xValue, yValue, ignoreCase))
                {
                    return false;
                }
            }
            else //Must be another object, recurse into said object
            {
                {
                    if (!PropertiesAreEqual(xValue, yValue, ignoreCase))
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    //Method to test simple primitive types
    private static bool valueTest<T>(T x, T y, bool ignoreCase)
    {
        if (x == null && y == null)
        {
            return true;
        }
        else if (x == null || y == null)
        {
            return false;
        }
        else if (x is string)
        {
            if (ignoreCase)
            {
                var xAsString = Convert.ToString(x);
                var yAsString = Convert.ToString(y);
                return string.Compare(xAsString, yAsString, false) == 0 ? true : false;
            }
        }

        return EqualityComparer<T>.Default.Equals(x, y);
    }

    private static bool canBeCompared(PropertyInfo x, PropertyInfo y)
    {
        return (x.PropertyType.IsPrimitive && y.PropertyType.IsPrimitive) || (x.PropertyType.IsValueType && y.PropertyType.IsValueType);
    }
}

