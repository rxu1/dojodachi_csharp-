using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("")]
    public IActionResult Index()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      return View(dojodachi);
    }

    [HttpGet("feed")]
    public IActionResult Eat()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      dojodachi.Feed();
      MakePets.SetDojodachi(HttpContext, dojodachi);
      return RedirectToAction("Index");
    }

    [HttpGet("play")]
    public IActionResult Playing()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      dojodachi.Play();
      MakePets.SetDojodachi(HttpContext, dojodachi);
      return RedirectToAction("Index");
    }

    [HttpGet("work")]
    public IActionResult Working()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      dojodachi.Work(); 
      MakePets.SetDojodachi(HttpContext, dojodachi);
      return RedirectToAction("Index");
    }

    [HttpGet("sleep")]
    public IActionResult Sleeping()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      dojodachi.Sleep(); 
      MakePets.SetDojodachi(HttpContext, dojodachi);
      return RedirectToAction("Index");
    }

    [HttpGet("reset")]
    public IActionResult NewGame()
    {
      Pet dojodachi = MakePets.GetDojodachi(HttpContext);
      dojodachi.Reset();
      MakePets.SetDojodachi(HttpContext, dojodachi);
      return RedirectToAction("Index");
    }  
  }
}
