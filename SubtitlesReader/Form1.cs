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
                    _activePosition.ToString(),
                    ShowTimeCheckBox.Checked.ToString(),
                    ShowLoadingSettingsCheckBox.Checked.ToString()
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
                ShowTimeCheckBox.Checked = bool.Parse(lines[4]);
                ShowLoadingSettingsCheckBox.Checked = bool.Parse(lines[5]);


                LoadContent();
                ShowLinesFor(_activePosition);
                ShowHideSettings();
            }
            else
            {
                File.WriteAllLines(path, new List<string> { "", "", "0", "0","true","true" });
                _activePosition = 0;
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
            RenderItems(File1.Items.Take(LinesToShow), File2.Items.Take(LinesToShow));
            ContentVScrollBar.Maximum = new List<int> { File1.Items.Count - 1, File2.Items.Count - 1 }.Max();
            ContentVScrollBar.LargeChange = 10;
            ContentVScrollBar.SmallChange = 1;
            CorrectionNumericUpDown.Increment = 1;
            ContentVScrollBar.Value = _activePosition;
        }

        private void RenderItems(IEnumerable<SubtitleItem> items1, IEnumerable<SubtitleItem> items2)
        {
            File1ContentTextBox.Text = string.Join(Environment.NewLine, items1.Select(RenderItem));
            File2ContentTextBox.Text = string.Join(Environment.NewLine, items2.Select(RenderItem));
            //File1ContentTextBox.Text = string.Join(Environment.NewLine, items1.Select(i => i.Id.ToString("0000   ") + i.Content));
            //File2ContentTextBox.Text = string.Join(Environment.NewLine, items2.Select(i => i.Id.ToString("0000   ") + i.Content));
        }

        private string RenderItem(SubtitleItem item)
        {
            return ShowTimeCheckBox.Checked ? item.TimeStringStart + "   " + item.Content : item.Content;
        }

        private SubtitleFile File1 { get; set; }
        private SubtitleFile File2 { get; set; }

        private void ContentVScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            ShowLinesFor(e.NewValue);
        }

        private const int LinesToShow = 3;
        private void ShowLinesFor(int position)
        {
            if (File1 != null && File2 != null)
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

                RenderItems(File1.Items.Where(i => i.Id >= firstPost - limit && i.Id <= firstPost + limit),
                    File2.Items.Where(i => i.Id >= position - limit && i.Id <= position + limit));
            }
        }

        private void CorrectionNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ShowLinesFor(_activePosition);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void Content_ValueChanged(object sender, MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs handledArgs)
            {
                handledArgs.Handled = true;
                if (handledArgs.Delta > 0)
                {
                    ShowLinesFor(_activePosition - 1);
                }
                else
                {
                    ShowLinesFor(_activePosition + 1);
                }
            }
        }

        private void ScrollHandlerFunction_ValueChanged(object sender, MouseEventArgs e)
        {
            if (e is HandledMouseEventArgs handledArgs)
            {
                handledArgs.Handled = true;
                if ((handledArgs.Delta > 0) && CorrectionNumericUpDown.Value != CorrectionNumericUpDown.Maximum)
                {
                    CorrectionNumericUpDown.Value += 1;
                }
                else if (CorrectionNumericUpDown.Value != CorrectionNumericUpDown.Minimum)
                {
                    CorrectionNumericUpDown.Value += -1;
                }

            }
        }

        private void ShowTimeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ShowLinesFor(_activePosition);
        }

        private void ShowLoadingSettingsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
                ShowHideSettings();
        }

        private void ShowHideSettings()
        {
            var visible = ShowLoadingSettingsCheckBox.Checked;

            File1TextBox.Visible = visible;
            File2TextBox.Visible = visible;
            ChooseFile1Button.Visible = visible;
            ChooseFile2Button.Visible = visible;
            LoadButton.Visible = visible;
            Size = new Size(Size.Width,visible ? 333 :280);

            File1ContentTextBox.Location = new Point(File1ContentTextBox.Location.X, visible ? 83 : 23);
            File2ContentTextBox.Location = new Point(File2ContentTextBox.Location.X, visible ? 189 : 129);

            CorrectionNumericUpDown.Location = new Point(CorrectionNumericUpDown.Location.X, visible ? 83 : 23);
            ContentVScrollBar.Location = new Point(ContentVScrollBar.Location.X, visible ? 109 : 49);

            ShowLoadingSettingsCheckBox.Location = new Point(ShowLoadingSettingsCheckBox.Location.X, visible ? 64 : 4);
            ShowTimeCheckBox.Location = new Point(ShowTimeCheckBox.Location.X, visible ? 64 : 4);
        }
    }
}
