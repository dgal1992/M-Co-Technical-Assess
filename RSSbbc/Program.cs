using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; // probably an easier alternative
using System.Xml;
using System.IO;
/*
 /////////////// Summary //////////////////
 -Parts of this technical assessment was rather new although not the methodology, more of the syntax of C#
 -Understanding the task at hand is very simple and self explanatory although more practice with similar coding is probably
 necessary
 -One problem was trying to solve the duplucated articles if the file is already present with articles.
 -Although in the specification the coding for the program to run every hour is not necessary the code for searching duplicated articles is not implemented.
 -Again the implementation of returning a json file without any items is not present either*/


namespace RSSbbc
{
    class Program
    {
                
        static void Main(string[] args)
        {
            //paths to a folder, I coded this to find my desktop 
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\feed";
            //url given 
            string url = "http://feeds.bbci.co.uk/news/uk/rss.xml";
            //calls getNews method to retrieve data from url string
            titleItems Items = Feeds.getNews(url);
            //Finds the folder to create a new document
            Feeds.FindFolder(folderPath);
            //creates new document
            Feeds.createJson(Items, folderPath);
        }
    }
}
