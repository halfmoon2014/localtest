using System.Windows.Forms;


    class ListColumn
    {
        private string key;
        private string text;
        private int width;
        /// <summary>
        /// 对齐方式
        /// </summary>
        private HorizontalAlignment m= HorizontalAlignment.Left;

    public string Key
    {
        get
        {
            return key;
        }

        set
        {
            key = value;
        }
    }

    public string Text
    {
        get
        {
            return text;
        }

        set
        {
            text = value;
        }
    }

    public int Width
    {
        get
        {
            return width;
        }

        set
        {
            width = value;
        }
    }

    public HorizontalAlignment M
    {
        get
        {
            return m;
        }

        set
        {
            m = value;
        }
    }

    public ListColumn(string text, int width)
        {
            Text = text;
            Width = width;
        }
        public ListColumn(string text)
        {
            Text = text;
            Width = 60;
        }

        public ListColumn(string text, int width,string key)
        {
            Text = text;
            Width = width;
            Key = key;
        }
        public ListColumn(string text,string key)
        {
            Text = text;
            Width = 60;
            Key = key;
        }

    }

