using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.IO.Compression;
using System.Threading;

namespace PlaybackModUtil
{
    public partial class Form1 : Form
    {
        int state = 2;
        ArrayList sounds = new ArrayList();
        String modsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\mods";
        String zipDir = ""; // This will be set in Form1()
        ZipFile zip;

        public Form1()
        {
            InitializeComponent();
            // Find the mod's zip directory
            bool isFound = false;
            foreach (String fN in Directory.GetFiles(modsDir))
            {
                if (fN.Substring(fN.LastIndexOf('\\') + 1, 7) == "iPodMod")
                {
                    zipDir = fN;
                    isFound = true;
                    break;
                }
            }
            if (isFound == false)
            {
                MessageBox.Show("iPod Mod wasn't found at " + modsDir, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // THIS.CLOSE()!!!!!!!!!!!!!!
            }
            zip = new ZipFile(zipDir);
            ListAllSounds();
            setIcon(2);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ArrayList obj = new ArrayList();
            DialogResult result = importDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                setIcon(0);
                foreach (String fileName in importDialog.FileNames)
                {
                    obj.Add(fileName);
                }
                ImportSound(obj);
            }
        }

        private void lstSounds_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setIcon(0);
            String content = "";
            String tempDir = modsDir + @"\TEMP_23";
            String javaFile = Path.Combine(tempDir, "sounds.txt");
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            FileStream fs = File.Create(javaFile);
            StreamWriter writer = new StreamWriter(fs);

            foreach (String item in lstSounds.Items)
            {
                content += item + Environment.NewLine;
            }

            if(content.Length > 0) content = content.Substring(0, content.Length - 1);
            writer.Write(content);
            writer.Close();
            writer.Dispose();

            String entry = "org/TeamL33T/IpodMod/sounds.txt/";
            zip.BeginUpdate();
            zip.Delete(entry);
            zip.Add(javaFile, entry);
            zip.CommitUpdate();

            Directory.Delete(tempDir, true);
            setIcon(2);
        }


        private void ListAllSounds()
        {
            lstSounds.Items.Clear();
            foreach (ZipEntry zipEntry in zip)
            {
                if (zipEntry.Name.Length <= 20) continue;
                if (zipEntry.Name.Substring(0, 21) == "assets/ipodmod/sound/")
                {
                    if (!zipEntry.IsFile) continue; // Ignore directories
                    lstSounds.Items.Add(zipEntry.Name.Substring(21));
                }
            }
            setIcon(1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lstSounds.SelectedIndex < 0)
            {
                MessageBox.Show("Please pick a sound to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                setIcon(0);
                RemoveSound(lstSounds.SelectedItem.ToString());
            }
            ListAllSounds();
        }

        private void ImportSound(ArrayList oggPaths)
        {
            setIcon(0);
            zip.BeginUpdate();
            foreach (String oggPath in oggPaths)
            {
                String oggName = oggPath.Substring(oggPath.LastIndexOf('\\') + 1);
                zip.Add(oggPath, "assets/ipodmod/sound/" + oggName);
            }
            zip.CommitUpdate();
            ListAllSounds();
        }

        private void RemoveSound(string oggName)
        {
            zip.BeginUpdate();
            foreach (ZipEntry zipEntry in zip)
            {
                if (zipEntry.Name == "assets/ipodmod/sound/" + oggName)
                {
                    zip.Delete(zipEntry.Name);
                    break;
                }
            }
            zip.CommitUpdate();
            ListAllSounds();
        }

        private void setIcon(int index)
        {
            switch (index)
            {
                case 0:
                    statGreen.Visible = false;
                    statYellow.Visible = false;
                    statRed.Visible = true;
                    break;
                case 1:
                    statGreen.Visible = false;
                    statYellow.Visible = true;
                    statRed.Visible = false;
                    break;
                case 2:
                    statGreen.Visible = true;
                    statYellow.Visible = false;
                    statRed.Visible = false;
                    break;
            }

            state = index;
            Application.DoEvents();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (state == 0)
            {
                e.Cancel = true;
                MessageBox.Show("You cannot close iPod Mod Sound Importer while it is doing a process because it will corrupt the mod files.", "User Interaction Terminated", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (state == 1)
            {
                button1_Click(null, null);
            }
        }

    }
}
