using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Models
{
  public static class MakePets
  {
    public static void SetDojodachi(HttpContext context, Pet dachi)
    {
      context.Session.SetString("dojo", JsonConvert.SerializeObject(dachi));
    }

    public static Pet GetDojodachi(HttpContext context)
    {
      string dojodachi = context.Session.GetString("dojo");
      if(dojodachi == null)
      {
        Pet dachi = new Pet();
        context.Session.SetString("dojo", JsonConvert.SerializeObject(dachi));
        return dachi;
      }
      else 
      {
        Pet dachi = JsonConvert.DeserializeObject<Pet>(dojodachi);
        return dachi; 
      }
    }
  }
}