using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {

        public IActionResult Index(int luck) 
        {
            Random rand = new Random();
            //TODO: add your string builder and HTML from Exercise 0 here
            int[] spin = new int[] 
            { 
               rand.Next(1,10),
               rand.Next(1,10),
               rand.Next(1,10)
            };
            bool isLucky = false;

            for (int i = 0; i < 3; i++)
                {       
                    if (spin[i] == luck)
                    {          
                    isLucky = true;
                    }
                }   

            StringBuilder htmlToShow =
                new StringBuilder("<body><h1>Lucky Spin - by Danish</h1>" +
                                  "<button onclick='history.go(0)'>Spin</button>");

            htmlToShow.Append("<div>" + spin[0] + "</div>");
            htmlToShow.Append("<div>" + spin[1] + "</div>");
            htmlToShow.Append("<div>" + spin[2] + "</div>");
            if (isLucky){
            htmlToShow.Append("<img src='http://studentfolders.cascadia.edu/itweb285/LuckySpinCoins.jpg'/>");
            htmlToShow.Append("</body>");
            }

            //TODO: Modify this to use the string builder's response string as the Content property's value
            return new ContentResult { Content = htmlToShow.ToString(), ContentType="text/html"};
        }
    }
}