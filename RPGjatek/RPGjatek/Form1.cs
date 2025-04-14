using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RPGjatek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        class StoryNode
        {
            public string ID { get; set; }
            public List<string> TextLines { get; set; } = new List<string>();
            public Dictionary<string, string> Choices { get; set; } = new Dictionary<string, string>();
            public string Background { get; set; }
        }

        private Dictionary<string, StoryNode> storyNodes = new Dictionary<string, StoryNode>();
        private string currentNodeId = "Start";
        private StoryNode currentNode;

        private void DisplayNode(string nodeId)
        {
            if (!storyNodes.ContainsKey(nodeId)) return;

            currentNodeId = nodeId;
            currentNode = storyNodes[nodeId];
            richTextBox1.Clear();

            // Háttér beállítása
            if (currentNode.Background == "bg1.png")
            {
                Background.Image = Properties.Resources.bg1;
                Background.SizeMode = PictureBoxSizeMode.StretchImage;
            }




            // Összes szöveg megjelenítése, külön sorban
            foreach (var line in currentNode.TextLines)
            {
                richTextBox1.AppendText(line + Environment.NewLine);
            }

            // Opciók megjelenítése egy sorban
            if (currentNode.Choices.Count > 0)
            {
                richTextBox1.AppendText(Environment.NewLine + "Options: ");
                foreach (var choice in currentNode.Choices.Keys)
                {
                    richTextBox1.AppendText(choice + "   ");
                }
                richTextBox1.AppendText(Environment.NewLine);
            }

            input.Clear();
            input.Focus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Parent = Background;
            pictureBox3.Parent = Background;

            if (File.Exists("scripts.txt"))
            {
                string[] lines = File.ReadAllLines("scripts.txt");
                StoryNode currentNode = null;

                foreach (string line in lines)
                {
                    if (line.StartsWith("[ID:"))
                    {
                        string id = line.Substring(4, line.Length - 5).Trim();
                        currentNode = new StoryNode { ID = id };
                        storyNodes[id] = currentNode;
                    }
                    else if (line.StartsWith("TEXT:") && currentNode != null)
                    {
                        currentNode.TextLines.Add(line.Substring(5).Trim());
                    }
                    else if (line.StartsWith("CHOICE:") && currentNode != null)
                    {
                        string choiceLine = line.Substring(7).Trim();
                        var parts = choiceLine.Split('=');
                        if (parts.Length == 2)
                        {
                            string option = parts[0].Trim();
                            string targetId = parts[1].Trim();
                            currentNode.Choices[option] = targetId;
                        }
                    }
                    else if (line.StartsWith("BG:") && currentNode != null)
                    {
                        currentNode.Background = line.Substring(3).Trim();
                    }
                }

                DisplayNode("Start");
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void continueBtn_Click(object sender, EventArgs e)
        {
            string inputValasz = input.Text.Trim();

            if (currentNode != null && currentNode.Choices.ContainsKey(inputValasz))
            {
                string nextNodeId = currentNode.Choices[inputValasz];
                DisplayNode(nextNodeId);
            }
            else
            {
                MessageBox.Show("Érvénytelen választás.");
            }
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (currentNode != null && currentNode.Choices.Count > 0)
            {
                string valasz = input.Text.Trim();
                continueBtn.Enabled = currentNode.Choices.ContainsKey(valasz);
            }
        }
    }
}
