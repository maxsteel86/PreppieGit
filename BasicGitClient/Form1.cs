﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicGitClient
{
    public partial class Form1 : Form
    {
        private GitClientAccess gitClient;
        private string error, output;
        // TODO: Make this come from a config file and not hard coded..
        private static string defaultDir = @"E:\Documents and Settings\Nikeah\My Documents\Python\Python_2014";

        public Form1()
        {
            InitializeComponent();
            gitClient = new GitClientAccess();
        }

        private void btnSetDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (Directory.Exists(defaultDir))
            {
                fbd.SelectedPath = defaultDir;
            }

            DialogResult result = fbd.ShowDialog();

            string directory = fbd.SelectedPath;
            tbDirectory.Text = directory;

            gitClient.SetDirectory(directory);
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);
            
            tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.ADD_ALL, out output, out error);

            if (String.Equals(String.Empty, output) && String.Equals(String.Empty, error))
            {
                tbOutput.AppendText(Environment.NewLine + "Added all modified files.  Check status" + Environment.NewLine);
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            gitClient.RunGitCommand(GitCommands.STATUS, out output, out error);
            
            tbOutput.AppendText(output.Replace("\n", Environment.NewLine));
            tbOutput.AppendText(error.Replace("\n", Environment.NewLine));
        }
    }
}
