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
                if (fN.Substring(fN.LastIndexOf('\\') + 1, 10) == "iPodProMod")
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
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ArrayList obj = new ArrayList();
            DialogResult result = importDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
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
            // Still Buggy (Last thing to fix!!)
            // Just found out that you need java (de)compiler stuff
            // You cannot find any file such as OggSounds.java in the mod zip

            String tempDir = modsDir + @"\TEMP_23";
            String javaFile = Path.Combine(tempDir, "OggSounds.java");
            if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);
            FileStream fs = new FileStream(javaFile, FileMode.Create, FileAccess.ReadWrite);

            foreach (ZipEntry zipEntry in zip)
            {
                if (!zipEntry.IsFile) continue;
                if (zipEntry.Name == "org/TeamL33T/IpodMod/OggSounds.java")
                {
                    zip.GetInputStream(zipEntry).CopyTo(fs);
                    break;
                }
            }

            StreamReader reader = new StreamReader(fs);
            String content = reader.ReadToEnd();
            content = content.Substring(content.LastIndexOf(';') + 1);
            String endContent = "";
            ArrayList newLines = new ArrayList();
            ArrayList codeLines = new ArrayList();

            foreach (String ogg in lstSounds.Items)
            {
                newLines.Add(ogg);
            }

            foreach (String line in newLines)
            {
                endContent = "\nevent.manager.addSound(\"ipodmod:" + line + "\");";
                codeLines.Add(endContent);
            }

            foreach (String codeLine in codeLines)
            {
                content += codeLine;
            }

            content += "\n{
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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lstSounds.SelectedIndex < 0)
            {
                MessageBox.Show("Please pick a sound to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else {
                RemoveSound(lstSounds.SelectedItem.ToString());
            }
            ListAllSounds();
        }

        private void ImportSound(ArrayList oggPaths)
        {
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

    }
}
