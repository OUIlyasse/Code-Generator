using BL.Configs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Generator.Sub.CSharp
{
    public partial class frmEvents : Form
    {
        #region Variables

        private string control;
        private string field;
        private List<Events> evs;
        public Events ev { get; set; }

        #endregion Variables

        private void fillListBox()
        {
            foreach (string e in Tools.Tools.GetAllControlEvents(control).OrderBy(x => x))
                lbEvents.Items.Add(e);
        }

        private void fillListBox(Events ev)
        {
            foreach (string e in Tools.Tools.GetAllControlEvents(control).OrderBy(x => x))
            {
                if (ev.EventsName.Contains(e))
                    lbEventsAdded.Items.Add(e);
                else
                    lbEvents.Items.Add(e);
            }
        }

        private void SortListBox()
        {
            var sortedItems = lbEvents.Items.Cast<string>().OrderBy(item => item).ToArray();
            lbEvents.Items.Clear();
            lbEvents.Items.AddRange(sortedItems);

            var sortedItem = lbEventsAdded.Items.Cast<string>().OrderBy(item => item).ToArray();
            lbEventsAdded.Items.Clear();
            lbEventsAdded.Items.AddRange(sortedItem);
        }

        public frmEvents(string control, string field, List<Events> evs, Events ev = null)
        {
            InitializeComponent();
            Text = $"Events Of {control}";
            this.evs = evs;
            this.control = control;
            this.field = field;
            if (ev == null)
            {
                ev = new Events();
                fillListBox();
            }
            else
            {
                this.ev = ev;
                fillListBox(ev);
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (string item in lbEvents.Items)
                lbEventsAdded.Items.Add(item);
            lbEvents.Items.Clear();
            SortListBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbEvents.SelectedItem != null)
            {
                //int selectedIndex = lbEvents.SelectedIndex;
                lbEventsAdded.Items.Add(lbEvents.SelectedItem);
                lbEvents.Items.Remove(lbEvents.SelectedItem);
                SortListBox();
                //lbEvents.SelectedIndex = selectedIndex;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbEventsAdded.SelectedItem != null)
            {
                //int selectedIndex = lbEventsAdded.SelectedIndex;
                lbEvents.Items.Add(lbEventsAdded.SelectedItem);
                lbEventsAdded.Items.Remove(lbEventsAdded.SelectedItem);
                SortListBox();
                //lbEventsAdded.SelectedIndex = selectedIndex;
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            foreach (string item in lbEventsAdded.Items)
                lbEvents.Items.Add(item);
            lbEventsAdded.Items.Clear();
            SortListBox();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //foreach (string item in lbEventsAdded.Items)
            //    ev.EventsName.Add(item);
            if (ev == null)
            {
                ev = new Events();
                ev.Field = field;
                ev.EventsName = lbEventsAdded.Items.Cast<string>().ToList();
                evs.Add(ev);
            }
            else
            {
                ev.EventsName.Clear();
                ev.EventsName = lbEventsAdded.Items.Cast<string>().ToList();
            }
            //ev.Field = field;
            //foreach (string item in lbEventsAdded.Items)
            //    ev.EventsName.Add(item);

            DialogResult = DialogResult.OK;
        }
    }
}