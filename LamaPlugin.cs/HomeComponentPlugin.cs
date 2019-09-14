using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TMXmlRpcLib;

namespace LamaPlugin
{
    public class HomeComponentPlugin : UserControl, IHomeComponent, IDragAndDropControl
    {
        bool clickDown = false;
        Point mouseDownLocation;

        public HomeComponentPlugin()
        {
            PluginType = PluginType.HomeComponent;
            Requirements = new List<Requirement>();
            base.MouseClick += new MouseEventHandler(_mouseClick);
            base.MouseDown += new MouseEventHandler(_mouseDown);
            base.MouseUp += new MouseEventHandler(_mouseUp);
            base.MouseMove += new MouseEventHandler(_mouseMove);
        }

        private void _mouseMove(object sender, MouseEventArgs e)
        {
            if (clickDown)
            {
                CheckCanMove();
                base.Left = e.X + base.Left - this.mouseDownLocation.X;
                base.Top = e.Y + base.Top - this.mouseDownLocation.Y;
            }
        }

        private void _mouseUp(object sender, MouseEventArgs e)
        {
            this.clickDown = false;
        }

      
        private void _mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownLocation = e.Location;
                this.clickDown = true;
            }
            
        }

        private void _mouseClick(object sender, MouseEventArgs e)
        {
         
        }

        protected Dictionary<int, string> handles = new Dictionary<int, string>();

        protected void asyncRequest(String methodeName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.handles.Add(this.client.AsyncRequest(methodeName, param, onGbxAsyncResult), methodeName);
        }

        protected void asyncRequest(GbxCallCallbackHandler handler, String methodName, params object[] param)
        {
            if (param == null)
                param = new object[] { };
            this.client.AsyncRequest(methodName, param, handler);
        }

        protected void asyncRequest(String methodName, GbxCallCallbackHandler handler)
        {
            this.client.AsyncRequest(methodName, new object[] { }, handler);
        }

        protected void addMouseEvents(Control c)
        {
            c.Click += (sender, e) => { OnClick(e); };
            c.MouseUp += (sender, e) => { OnMouseUp(e); };
            c.MouseDown += (sender, e) => { OnMouseDown(e); };
            c.MouseMove += (sender, e) => { OnMouseMove(e); };
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Abstract ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
        protected virtual void onGbxAsyncResult(GbxCall res)
        {
            throw new NotImplementedException();
        }

        public virtual void onGbxCallBack(GbxCallbackEventArgs res)
        {
            throw new NotImplementedException();
        }

        public void CheckCanMove()
        {
            this.CanMoveUp = (this.Location.Y > this.Parent.Location.Y);
            this.CanMoveDown = (this.Location.Y + this.Height < this.Parent.Location.Y + this.Parent.Height);
            this.CanMoveLeft = (this.Location.X > this.Parent.Location.X);
            this.CanMoveUp = (this.Location.X + this.Width < this.Parent.Location.X + this.Parent.Width);
        }

        public XmlRpcClient client { get; set; }
        public HomeComponentType Type { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public List<Requirement> Requirements { get; set; }
        public string PluginName { get; set; }
        public string PluginFolder { get; set; }
        public PluginType PluginType { get; set; }
        public OnError OnError { get; set; }
        public Logger Log { get; set; }
        public bool CanMoveLeft { get; set; }
        public bool CanMoveRight { get; set; }
        public bool CanMoveUp { get; set; }
        public bool CanMoveDown { get; set; }
    }
}
