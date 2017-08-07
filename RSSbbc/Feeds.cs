using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Syndication; //Service model for the SyndicationFeed
using Newtonsoft.Json; //know way although easier method may apply 
using System.IO; //primarily for directory location

namespace RSSbbc
{
    class Feeds
    {
        public static titleItems getNews(String url)
        {
            //declared at this stage to return the value
            titleItems mainItems;
           //using the xml reader to read the url passed through from Program class
            using (System.Xml.XmlReader rdr = System.Xml.XmlReader.Create(url))
            {
                //Syndication feed loads the feed from the given url
                SyndicationFeed feed = SyndicationFeed.Load(rdr);

                //declaring mainItems class
                mainItems = new titleItems();
                //declaring the itemlist of child news items
                List<Items> itemList = new List<Items>();

                //for each item within the feed
                foreach (var item in feed.Items)
                {
                    // creation of main object follows the children containing each news feed
                    if (item.Title.Text == "BBC News Channel")
                    {
                        //sets the main title, link and desc if the title text == the title usually given
                        //very error prone although it works in this instance
                        mainItems.title = item.Title.Text;
                        mainItems.link = item.Id;
                        mainItems.description = item.Summary.Text;

                    }
                    else
                    {
                        
                        //otherwise it sets the items accordingly
                        Items newsItemList = new Items();
                        newsItemList.title = item.Title.Text;
                        newsItemList.link = item.Id;
                        newsItemList.description = item.Summary.Text;
                        newsItemList.pubDate = item.PublishDate.ToString();

                        // adds the news to the main object 
                        itemList.Add(newsItemList);
                    }
                }

                mainItems.items = itemList;
                //close reader once we have finished reading feed and return feed object.
                rdr.Close();

            }
            //value being returned
            return mainItems;
        }
        //locates the folder directory although I manually created this and is located on the desktop for ease
        public static void FindFolder(string fpath)
        {
            Directory.GetDirectories(fpath);
        }

       public static void createJson(titleItems tI, string path)
        {
            //strings the path of the file and alters the name of the file in accordance to the format given
            //altering the datetime.now structure is necessary
            string filePath = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd-HH") + ".json";

            //the object is serialized
            string json = JsonConvert.SerializeObject(tI, Formatting.Indented);
            //the object is then deserialized ready to be written
            tI = JsonConvert.DeserializeObject<titleItems>(json);
            //appends the data to the file using the path and the object
            File.AppendAllText(@filePath, json);
            
        }
    }
}
