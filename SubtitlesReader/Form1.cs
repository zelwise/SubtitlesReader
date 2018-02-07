using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubtitlesReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //File1TextBox.Text = "d:\\GitProjects\\SubtitlesReader\\Altered.Carbon.S01E01.1080p_track4_eng.srt";
            //File2TextBox.Text = "d:\\GitProjects\\SubtitlesReader\\Altered.Carbon.S01E01.1080p_track3_rus.srt";


            ReadConfig();
        }

        private string GetConfigPath()
        {
            return System.Reflection.Assembly.GetEntryAssembly().Location + ".settings";
        }

        private int _activePosition = 0;

        private void SaveConfig()
        {
            var path = GetConfigPath();
            File.WriteAllLines(path,
                new List<string>
                {
                    File1TextBox.Text,
                    File2TextBox.Text,
                    CorrectionNumericUpDown.Value.ToString(),
                    _activePosition.ToString()
                });
        }

        private void ReadConfig()
        {
            var path = GetConfigPath();
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                File1TextBox.Text = lines[0];
                File2TextBox.Text = lines[1];
                CorrectionNumericUpDown.Value = int.Parse(lines[2]);
                _activePosition = int.Parse(lines[3]);


                LoadContent();
                ShowLinesFor(_activePosition);
            }
            else
            {
                File.WriteAllLines(path,new List<string>{"","","0","0"});
            }
        }

        private void ChooseFile1Button_Click(object sender, EventArgs e)
        {
            //File1OpenFileDialog.FileName =;
            if (File1OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(File1OpenFileDialog.FileName))
                {
                    File1TextBox.Text = File1OpenFileDialog.FileName;
                }
            }
        }

        private void ChooseFile2Button_Click(object sender, EventArgs e)
        {
            //File2OpenFileDialog.FileName =;
            if (File2OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(File2OpenFileDialog.FileName))
                {
                    File2TextBox.Text = File2OpenFileDialog.FileName;
                }
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadContent();
        }

        private void LoadContent()
        {
            File1 = SubtitleFileReader.ReadFile(File1TextBox.Text);
            File2 = SubtitleFileReader.ReadFile(File2TextBox.Text);
            File1ContentTextBox.Text = string.Join(Environment.NewLine, File1.Items.Take(LinesToShow).Select(i => i.Id.ToString("0000   ") + i.Content));
            File2ContentTextBox.Text = string.Join(Environment.NewLine, File2.Items.Take(LinesToShow).Select(i => i.Id.ToString("0000   ") + i.Content));
            ContentVScrollBar.Maximum = new List<int> { File1.Items.Count - 1, File2.Items.Count - 1 }.Max();
            ContentVScrollBar.LargeChange = 10;
            ContentVScrollBar.SmallChange = 1;
            ContentVScrollBar.Value = _activePosition;
        }

        private SubtitleFile File1 { get; set; }
        private SubtitleFile File2 { get; set; }
        
        private void ContentVScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            ShowLinesFor(e.NewValue);
        }

        private const int LinesToShow = 5;
        private void ShowLinesFor(int position)
        {
            _activePosition = position;

            int limit = LinesToShow / 2;

            if (position <= limit)
            {
                position = limit;
            }
            
            var firstPost = position - CorrectionNumericUpDown.Value;
            if (firstPost < limit)
            {
                firstPost = limit;
            }
            
            File1ContentTextBox.Text = string.Join(Environment.NewLine, File1.Items.Where(i=> i.Id >= firstPost - limit && i.Id <= firstPost + limit).Select(i => i.Id.ToString("0000   ") + i.Content));
            File2ContentTextBox.Text = string.Join(Environment.NewLine, File2.Items.Where(i => i.Id >= position - limit && i.Id <= position + limit).Select(i => i.Id.ToString("0000   ") + i.Content));
        }

        private void CorrectionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }
    }
}
