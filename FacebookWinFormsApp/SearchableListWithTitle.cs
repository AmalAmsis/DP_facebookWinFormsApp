using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class SearchableListWithTitle : UserControl
    {
        public SearchableListWithTitle()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedIndexChanged;

        public string Title
        {
            get { return this.labelTitle.Text; }
            set { this.labelTitle.Text = value; }
        }

        public ListBox.ObjectCollection Items
        {
            get { return listBox.Items; }
        }

        public string DisplayMember 
        {
            get { return listBox.DisplayMember; }
            set { listBox.DisplayMember = value; }
        }

        public Object SelectedItem 
        {
            get { return listBox.SelectedItem; }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox.SelectedIndex > -1)
            {
                object selectedItem = listBox.SelectedItem;
                SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
                textBoxSearch.Text = listBox.SelectedItem.ToString();
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listBox.ClearSelected();
            int foundIdx = listBox.FindString(textBoxSearch.Text);
            if(foundIdx > -1)
            {
                if(textBoxSearch.Text.ToLower() == listBox.Items[foundIdx].ToString().ToLower())
                {
                    listBox.SelectedIndex = foundIdx;
                }
                
                listBox.TopIndex = foundIdx;
            }
        }
    }
}
