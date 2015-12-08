using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKP.KRD.Gamification;

namespace SKP.KRD
{
    public partial class CharacterDetailsForm : Form
    {
        public CharacterDetailsForm(Character character)
        {
            InitializeComponent();
            dataGridView1.DataSource = character._skills;
        }

        private void bInc_Click(object sender, EventArgs e)
        {
            var skill = (Skill)dataGridView1.CurrentRow.DataBoundItem;
            skill.IncreaseValue();
            dataGridView1.Refresh();
        }
    }
}
