using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class ListViewEx : ListView
{
    public ListViewEx()
    {
        //GotFocus += new EventHandler(listView1_GotFocus);
        //LostFocus += new EventHandler(listView1_LostFocus);
        HideSelection = true;
        //  Invalidated += new InvalidateEventHandler(listView_Validated);
        //ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView_ItemSelectionChanged);
    }
    class ItemColor
    {
        public Color ForeColor;
        public Color BackColor;
    }
    Dictionary<ListViewItem, ItemColor> dicItemColor = new Dictionary<ListViewItem, ItemColor>();
    void listView1_LostFocus(object sender, EventArgs e)
    {
        Console.WriteLine("listView1_LostFocus");
        HideSelection = true;
        // dicItemColor.Clear();
        foreach (ListViewItem item in SelectedItems)
        {
            ItemColor ic = null;
            if (!dicItemColor.ContainsKey(item))
            {
                ic = new ItemColor() { ForeColor = item.ForeColor, BackColor = item.BackColor };
                dicItemColor.Add(item, ic);
            }
            item.ForeColor = Color.White;
            item.BackColor = SystemColors.Highlight;
        }

    }

    void listView1_GotFocus(object sender, EventArgs e)
    {
        Console.WriteLine("listView1_GotFocus");
        foreach (var ic in dicItemColor)
        {
            var item = ic.Key;
            var c = ic.Value;
            item.ForeColor = c.ForeColor;
            item.BackColor = c.BackColor;
        }
        foreach (ListViewItem item in SelectedItems)
        {
            item.ForeColor = Color.White;
            item.BackColor = SystemColors.Highlight;
        }
    }

    private void listView_Validated(object sender, EventArgs e)
    {
        if (FocusedItem != null)
        {
            FocusedItem.BackColor = SystemColors.Highlight;
            FocusedItem.ForeColor = Color.White;
        }
    }

    private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        Console.WriteLine("listView_ItemSelectionChanged");
        //  e.Item.ForeColor = Color.Black;
        // e.Item.BackColor = SystemColors.Window;
        listView1_LostFocus(null, null);
        listView1_GotFocus(null, null);
        return;
        //if (FocusedItem != null)
        //{
        //    // FocusedItem.Selected = true;
        //}

        //HideSelection = true;
        //foreach (ListViewItem item in Items)
        //{
        //    if (dicItemColor.ContainsKey(item))
        //    {
        //        var ic = dicItemColor[item];
        //        item.ForeColor = ic.ForeColor;
        //        item.BackColor = ic.BackColor;
        //    }
        //}
        //foreach (ListViewItem item in SelectedItems)
        //{
        //    item.ForeColor = Color.White;
        //    item.BackColor = SystemColors.Highlight;
        //}
    }
}
