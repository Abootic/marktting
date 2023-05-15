using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;


namespace markettng.Services
{
    public static class TempDataExtenstions
    {

        //public static bool AddMessage(this ITempDataDictionary tempData, AlertMessage msg)
        //{
        //    try
        //    {
        //        return tempData.SetTemp<AlertMessage>(key:"jjdsCustomeAlertMessage",value: msg);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("------------- Exception in SetTemp -----------");
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }

        //}
        public static bool SetTemp<T>(this ITempDataDictionary tempData,string key, T value)
        {
            try
            {
                tempData[key] = JsonSerializer.Serialize(value);
                if (tempData.ContainsKey(key))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------- Exception in SetTemp -----------");
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        public static T? GetTemp<T>(this ITempDataDictionary tempData, string key)
        { 
            T? value;
            try
            {                
                if (tempData.ContainsKey(key))
                {
                    object ob;
                   bool res= tempData.TryGetValue(key, out ob);
                    if (res)
                    {
                        if(ob != null)
                        {
                            value = JsonSerializer.Deserialize<T>((string)ob);
                            if (value != null)
                            {
                                return value;
                            }
                        }
                        else
                        {
                            return default;
                        }
                    }
                    else
                    {
                        return default;
                    }
                    
                }
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("------------- Exception in GetSave ---------------");
                Console.WriteLine(ex.ToString());
                return default;
            }
        }


        public static T? GetTempSave<T>(this ITempDataDictionary tempData, string key)
        {
            T? value;
            try
            {
                if (tempData.ContainsKey(key))
                {
                    object? ob;
                     ob = tempData.Peek(key);
                    if (ob != null)
                    {
                        value = JsonSerializer.Deserialize<T>((string)ob);
                        if (value != null)
                        {
                            return value;
                        }
                        else
                        {
                            return default;
                        }
                    }
                    else
                    {
                        return default;
                    }

                }
                return default;
            }
            catch (Exception ex)
            {            
                Console.WriteLine("------------- Exception in GetSave ---------------");
                Console.WriteLine(ex.ToString());
                return default;
            }
        }

        //public static AlertMessage? GetMessage(this ITempDataDictionary tempData)
        //{
        //    try
        //    {
        //        return tempData.GetTemp<AlertMessage>(key: "jjdsCustomeAlertMessage");

        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
