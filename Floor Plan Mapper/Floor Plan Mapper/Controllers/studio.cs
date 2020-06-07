using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json.Linq;

public class Studio : ContainerControl
{
    private Graphics G;
    public Studio()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
    }
    // <Control Properties>
    private SmoothingMode _Quality = SmoothingMode.AntiAlias;
    [Category("Appearance")]
    [DisplayName("Quality")]
    public SmoothingMode Quality
    {
        get
        {
            return _Quality;
        }
        set
        {
            _Quality = value;
        }
    }
    // </Control Properties>
    // <Company Properties>
    // Tabs
    public VectorCollection _Vectors = new VectorCollection();
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Tab Settings")]
    [DisplayName("Vectors")]
    public VectorCollection Vectors
    {
        get
        {
            return _Vectors;
        }
        set
        {
            _Vectors = value;
        }
    }
    public Image _Image;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Image Settings")]
    [DisplayName("Image")]
    public Image Image
    {
        get
        {
            return _Image;
        }
        set
        {
            _Image = value;
        }
    }
    public String _type;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Type")]
    public String Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }
    public bool _addScreen;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Add Screen")]
    public bool AddScreen
    {
        get
        {
            return _addScreen;
        }
        set
        {
            _addScreen = value;
        }
    }
    public bool _addFast;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Add Fast")]
    public bool AddFast
    {
        get
        {
            return _addFast;
        }
        set
        {
            _addFast = value;
        }
    }
    public bool _addRoomFast;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Add Room")]
    public bool AddRoomFast
    {
        get
        {
            return _addRoomFast;
        }
        set
        {
            _addRoomFast = value;
        }
    }
    public bool _addDoorFast;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Add Door")]
    public bool AddDoorFast
    {
        get
        {
            return _addDoorFast;
        }
        set
        {
            _addDoorFast = value;
        }
    }
    public String _data;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Data")]
    public String Data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
        }
    }
    public String _buildingName;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Building Name")]
    [DisplayName("Data")]
    public String BuildingName
    {
        get
        {
            return _buildingName;
        }
        set
        {
            _buildingName = value;
        }
    }
    public String _floorNumber;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Building Name")]
    [DisplayName("Data")]
    public String FloorNumber
    {
        get
        {
            return _floorNumber;
        }
        set
        {
            _floorNumber = value;
        }
    }
    public Point _addPoint;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Add Point")]
    public Point AddPoint
    {
        get
        {
            return _addPoint;
        }
        set
        {
            _addPoint = value;
        }
    }
    public List<Point> _edges = new List<Point>();
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Category("Data Settings")]
    [DisplayName("Edges")]
    public List<Point> Edges
    {
        get
        {
            return _edges;
        }
        set
        {
            _edges = value;
        }
    }
    // ////
    // <c> Mouse Events, Functions, etc</c>
    // \\\\
    private Vector lastv = null;
    protected override void OnMouseMove(MouseEventArgs e)
    {
       
            this.Cursor = Cursors.Arrow;
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        this.Refresh();
    }
    protected override void OnKeyUp(KeyEventArgs e)
    {
        if (!e.Alt && altdown)
        {
            altdown = false;
        }
        this.Refresh();
    }
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.KeyCode == Keys.I && !_addScreen)
        {
            _addFast = !_addFast;
            this.Refresh();
        }
        else if (e.Control && e.KeyCode == Keys.S && !_addScreen)
        {
            saveJson();
        }
        else if (e.Control && e.KeyCode == Keys.O && !_addScreen)
        {
            loadJSON();
        }
        else if (e.Control && e.KeyCode == Keys.V && !_addScreen)
        {
            loadJSON(true);
        }
        if (_addScreen)
        {
            if (e.KeyValue == 13)
            {
                //Enter
                _addScreen = false;
                Vector newVector = new Vector();
                newVector.Location = _addPoint;
                newVector.Type = _type;
                newVector.Data = _data;
                newVector.Index = _Vectors.Count + 1;
                newVector.fillColor = randomColor();
                _Vectors.Add(newVector);
                lastv = _Vectors[_Vectors.Count - 1];
                _addScreen = false;
                this.Refresh();
            }
            else if (e.KeyValue == 8)
            {
                _data = "";
                this.Refresh();
            }
            else if (e.KeyValue == 27)
            {
                _addScreen = false;
                this.Refresh();
            }
            else
            {
                if (e.Shift && _addScreen)
                {
                    if (e.KeyCode.ToString().Length > 1)
                    {
                        _type = e.KeyCode.ToString().Substring(1, e.KeyCode.ToString().Length - 1);
                    }
                    else
                    {
                        _type = e.KeyCode.ToString();
                    }
                }
                else if (!e.Shift && _addScreen)
                {
                    if (e.KeyCode.ToString().Length > 1)
                    {
                        _data += e.KeyCode.ToString().Substring(1, e.KeyCode.ToString().Length - 1);
                    }
                    else
                    {
                        _data += e.KeyCode.ToString();
                    }
                }


            }
        }
        else
        {
            if (!_addScreen && e.Alt)
            {
                if (e.KeyCode.ToString().Length > 1)
                {
                    _data += e.KeyCode.ToString().Substring(1, e.KeyCode.ToString().Length - 1);
                }
                else
                {
                    _data += e.KeyCode.ToString();
                }
                _data = _data.Replace("enu", "");
                if (e.KeyCode == Keys.Back)
                {
                    try
                    {
                        _data = _data.Substring(0, _data.Length - 4);
                    }
                    catch (Exception ex)
                    {

                    }

                }
            }
            else if (!_addScreen && _addFast && e.Control && e.KeyCode == Keys.R && !_addDoorFast)
            {
                _addRoomFast = !_addRoomFast;
            }
            else if (!_addScreen && _addFast && e.Control && e.KeyCode == Keys.D && !_addRoomFast)
            {
                _addDoorFast = !_addDoorFast;
            }
        }
        if (e.Alt)
        {
            altdown = true;
        }
        if (e.Alt && e.KeyCode == Keys.Enter && !_addFast && !_addScreen && clickedV != null)
        {
            _data = _data.Replace("eturn", "");
            clickedV.Data = _data;
        }
        this.Refresh();
    }
    private Boolean altdown = false;
    private Vector clickedV = null;
    public void loadJSON(bool onlyV = false, string file = "")
    {
        var fileContent = string.Empty;
        var filePath = string.Empty;

        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            if (file == "")
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
            else
            {
                //Read the contents of the file into a stream
                var fileStream =File.OpenRead(file);

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
        }

        JObject o = JObject.Parse(fileContent);

        string name = (string)o["Building"];
        // Apple

        JArray vectors = (JArray)o["Vectors"];
        JArray edges = (JArray)o["Edges"];
        foreach (JObject s in vectors)
        {
            int max = s.Count + 1;
            for (int i = 1; i < max; i++)
            {
                Random rnd = new Random();
                int x = (int)((this.Width) * ((float)(s[name + i.ToString()]["X"])/ 100));
                int y = (int)((this.Height) * ((float)s[name + i.ToString()]["Y"] / 100));
                Vector newVector = new Vector();
                newVector.Location = new Point(x,y);
                newVector.Type = s[name + i.ToString()]["Type"].ToString();
                newVector.Data = s[name + i.ToString()]["Data"].ToString();
                newVector.Index = i;
                newVector.fillColor = Color.FromArgb(rnd.Next(0,205), rnd.Next(0, 255), rnd.Next(0, 255));
                _Vectors.Add(newVector);
            }
        }
        if (onlyV)
        {
            this.Refresh();
            return;
        }
        foreach (JObject s in edges)
        {
            int max = s.Count + 1;
            for (int i = 1; i < max; i++)
            {
                string p1 = s[i.ToString()]["1"].ToString().Replace(name, "");
                string p2 = s[i.ToString()]["2"].ToString().Replace(name, "");
                _edges.Add(new Point(Int32.Parse(p1), Int32.Parse(p2)));
            }
        }
        this.Refresh();
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        Vector vect = null;
        bool clicked = false;
        bool delete = false;
        if (e.Button == MouseButtons.Right)
        {
            delete = true;
        }
        foreach(Vector v in _Vectors)
        {
            if (v.Selected)
            {
                vect = v;
            }
            v.Selected = false;
        }

        foreach(Vector v in _Vectors)
        {
            Rectangle r = new Rectangle(v.Location.X, v.Location.Y, 10, 10);
            if (r.Contains(e.Location))
            {
                if (delete && !_addFast)
                {
                    _Vectors.Remove(v);
                    Point[] removeEdges = _edges.FindAll(x => x.X == v.Index || x.Y == v.Index).ToArray();
                    foreach(Point edge in removeEdges)
                    {
                        if (edge.Y == v.Index || edge.X == v.Index)
                        {
                            _edges.Remove(edge);
                        }
                    }
                    this.Refresh();
                    break;
                }
                else if(delete && _addFast)
                {
                    lastv = v;
                    this.Refresh();
                    break;
                }
                clicked = true;
                if (altdown)
                {
                    _data = v.Data;
                    clickedV = v;
                    v.Selected = true;
                }
                if (vect == null)
                {
                    v.Selected = true;
                }
                else
                {
                    if (!altdown)
                    {
                        _edges.Add(new Point(vect.Index, v.Index));
                        vect.Selected = false;
                    }
                }
            }
        }
        if (!clicked && !delete)
        {
            if (!_addFast && !_addDoorFast && !_addRoomFast)
            {
                _addScreen = true;
                _type = "I";
                _addPoint = e.Location;
            }
            else
            {
                Vector newVector = new Vector();
                newVector.Location = e.Location;
                newVector.Type = "I";
                newVector.Data = "";
                if (_addDoorFast)
                {
                    newVector.Type = "D";
                    newVector.Data = _data;
                }
                else if (_addRoomFast)
                {
                    newVector.Type = "R";
                    newVector.Data = _data;
                }
               
                newVector.Index = _Vectors.Count + 1;
                newVector.fillColor = randomColor();
                _Vectors.Add(newVector);
                lastv = _Vectors[_Vectors.Count - 1];
                if (_Vectors.Count >= 2)
                {
                    if (!_addRoomFast && !_addDoorFast)
                    {
                        _edges.Add(new Point(lastv.Index - 1, newVector.Index));
                        _edges.Add(new Point(lastv.Index, lastv.Index - 1));
                    }
                }
               
            }
            
        }
        this.Refresh();
    }
    public Color randomColor()
    {
        Random rnd = new Random();
        int r = rnd.Next(0, 180);
        int b = rnd.Next(0, 180);
        int g = rnd.Next(0, 185);
        return Color.FromArgb(r, g, b);
    }
    public void saveJson()
    {
        String output = "{";
        String nl = Environment.NewLine;
        string _buildingName2 = "Pearson";
        string _floorNumber2 = "1";
        output = "";
        output += "{" + nl;
        output += "\"Building\": \"" + _buildingName2 + "\"," + nl;
        output += "\"Floor\": \"" + _floorNumber2 + "\"," + nl;
        output += "\"Width\": " + this.Width + "," + nl;
        output += "\"Height\": " + this.Height + "," + nl;
        output += "\"Vectors\": [{" + nl;
        int counter = 0;
        foreach (var v in _Vectors)
        {
            counter++;
            float x = ((float)v.Location.X / (float)this.Width) * 100;
            float y = ((float)v.Location.Y / (float)this.Height) * 100;
            output += "\"" + _buildingName2 + v.Index + "\": {" + nl;
            output += "\"Data\": \"" + v.Data + "\"," + nl;
            output += "\"Type\": \"" + v.Type + "\"," + nl;
            output += "\"X\": \"" + x.ToString() + "\"," + nl;
            output += "\"Y\": \"" + y.ToString() + "\"" + nl;
            output += "}," + nl;
        }
        output += nl + "}]," + nl;
        output += "\"Edges\": [{" + nl;
        counter = 0;
        foreach (var edge in _edges)
        {
            counter++;
            output += "\"" + counter + "\": {" + nl;
            output += "\"1\": \"" + _buildingName2 + (edge.X + 1) + "\"," + nl;
            output += "\"2\": \"" + _buildingName2 + (edge.Y + 1) + "\"" + nl;
            output += "}," + nl;
        }
        output += nl + "}]" + nl;
        output += "}";
        File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/WriteText.txt", output);
      
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        if (_Image != null)
        {
            G.DrawImage(_Image, new Rectangle(0,0, this.Width, this.Height));
        }
        G.DrawString("W: " + this.Width.ToString() + ", H: " + this.Height.ToString() + ", Add Fast(I: R-" + _addRoomFast.ToString().Substring(0, 1) + " - D-" + _addDoorFast.ToString().Substring(0, 1) + "): " + _addFast.ToString() + ", Delete by right click", new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.Black), new Point(0, 0)) ;
        G.DrawString("Save = Ctrl + S, Open = Ctrl + O, Open Vectors = Ctrl + V", new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.Black), new Point(0, 20));
        G.DrawString("Create Edges by clicking one & then the other: " + _data + " - Alt:" + altdown.ToString() + " - C: ", new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.Black), new Point(0, 40));
        try
        {
            foreach (Vector v in _Vectors)
            {
                G.FillEllipse(new SolidBrush(v.fillColor), new Rectangle(v.Location.X, v.Location.Y, 10, 10));
                G.DrawRectangle(new Pen(v.fillColor), new Rectangle(v.Location.X, v.Location.Y, 10, 10));
                if (v.Selected)
                {
                    G.FillRectangle(new SolidBrush(Color.FromArgb(150, 0,190, 190)), new Rectangle(v.Location.X, v.Location.Y, 10, 10));
                }
                G.DrawString(v.Index.ToString(), new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.Black), new Point(v.Location.X - 10, v.Location.Y - 10));
            }
            foreach (Point p in _edges)
            {
                int p1 = p.X;
                int p2 = p.Y;
                Vector v1 = null;
                Vector v2 = null;
                Color c = Color.Red;
                int offset = 0;
                if (p2 > p1)
                {
                    offset += 10;
                    c = Color.Blue;
                }
                foreach(Vector v in _Vectors)
                {
                    
                    if (v.Index == p1)
                    {
                        v1 = v;
                    }
                    if (v.Index == p2)
                    {
                        v2 = v;
                    }
                }
                G.DrawLine(new Pen(c), v1.Location.X + offset, v1.Location.Y + offset, v2.Location.X + offset, v2.Location.Y + offset);
            }
            if (_addScreen && !_addDoorFast && !_addRoomFast)
            {
                G.FillRectangle(new SolidBrush(Color.FromArgb(200, 0, 0, 0)), new Rectangle(0, 0, this.Width, this.Height));
                
                G.DrawString("Room Number(type #'s): " + _data, new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.White), new Point(this.Width / 2, this.Height / 2));
                G.DrawString("Type (type R=Room, D=Door, I=Intersection): " + _type, new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.White), new Point(this.Width / 2, this.Height / 2 + 25));
                G.DrawString("[Enter] to save, [Esc] to cancel " + _type, new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.White), new Point(this.Width / 2, this.Height / 2 + 55));
            }
            
        }
        catch (Exception ex)
        {

        }
    }

    public class VectorCollection : List<Vector>
    {
        public VectorCollection()
        {
        }
        public new void Add(Vector Tab)
        {
            base.Add(Tab);
        }
        public new void AddRange(List<Vector> Range)
        {
            base.AddRange(Range);
        }
        public new void Clear()
        {
            base.Clear();
        }
        public new void Remove(Vector Item)
        {
            base.Remove(Item);
        }
        public new void RemoveAt(int Index)
        {
            base.RemoveAt(Index);
        }
        public new void RemoveAll(System.Predicate<Vector> Predicate)
        {
            base.RemoveAll(Predicate);
        }
        public new void RemoveRange(int Index, int Count)
        {
            base.RemoveRange(Index, Count);
        }
    }
    public class Vector
    {
        [Category("Data")]
        [DisplayName("Selected")]
        public bool Selected { get; set; } = false;
        [Category("Data")]
        [DisplayName("Mouse Over")]
        public bool Hover { get; set; } = false;
        [Category("Data")]
        [DisplayName("Tab Index")]
        public int Index { get; set; } = 0;
        [Category("Data")]
        [DisplayName("Location(Don't Touch)")]
        public Point Location { get; set; } = new Point(0, 0);
        [Category("Data")]
        [DisplayName("Data")]
        public string Data { get; set; } = "104";
        [Category("Data")]
        [DisplayName("Type")]
        public string Type { get; set; } = "Room";
        [Category("Data")]
        [DisplayName("Color")]
        public Color fillColor { get; set; } = Color.Red;
        protected Guid UniqueId;
        public Vector()
        {
            UniqueId = Guid.NewGuid();
        }
        public override string ToString()
        {
            return Data;
        }
    }
        
}

