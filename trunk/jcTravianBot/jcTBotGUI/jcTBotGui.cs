using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jcTBotGUI
{
	public partial class jcTBotGui : Form
	{
		public jcTBotGui()
		{
			InitializeComponent();
		}

		private void buttonClear_Click(object sender, EventArgs e)
		{
			textBoxStatus.Text = "";
		}

		private void jcTBotGui_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'jcTBotDataSet.Tasks' table. You can move, or remove it, as needed.
			this.tasksTableAdapter.Fill(this.jcTBotDataSet.Tasks);
			// TODO: This line of code loads data into the 'jcTBotDataSet.TaskList' table. You can move, or remove it, as needed.
			this.taskListTableAdapter.Fill(this.jcTBotDataSet.TaskList);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Buildings' table. You can move, or remove it, as needed.
			this.buildingsTableAdapter.Fill(this.jcTBotDataSet.Buildings);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Resources' table. You can move, or remove it, as needed.
			this.resourcesTableAdapter.Fill(this.jcTBotDataSet.Resources);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Villages' table. You can move, or remove it, as needed.
			this.villagesTableAdapter.Fill(this.jcTBotDataSet.Villages);

		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{

		}

		private void Tasks_Click(object sender, EventArgs e)
		{

		}
	}
}