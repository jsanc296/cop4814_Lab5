using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L2;
using System.IO;
using System.Xml.Serialization;

namespace GameFactory
{
    public partial class Form1 : Form
    {
        StreamWriter sw;
        XmlSerializer serial;
        List<Game> gameList;
        const string GAME_FILENAME = @"..\..\game.xml";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sw = new StreamWriter(GAME_FILENAME);
            gameList = new List<Game>();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Game G = new Game("Dolphins", "Patriots", 50, 3);
            gameList.Add(G);
            G = new Game("Ravens", "Packers", 10, 21);
            gameList.Add(G);
            G = new Game("Browns", "Steelers", 30, 13);
            gameList.Add(G);
            G = new Game("Giants", "Jets", 17, 0);
            gameList.Add(G);

            serial = new XmlSerializer(gameList.GetType());
            serial.Serialize(sw, gameList);
            sw.Close();
        }

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            gameList = new List<Game>();
            StreamReader sr = new StreamReader(GAME_FILENAME);
            serial = new XmlSerializer(gameList.GetType());
            gameList = (List<Game>)serial.Deserialize(sr);
            sr.Close();

            foreach( Game G in gameList)
            {
                lstGame.Items.Add(G.ToString());
            }
        }
    }
}
