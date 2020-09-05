using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TMXmlRpcLib;
using static LamaPlugin.StaticM;

namespace LamaPlugin
{
    public class HomeComponentPlugin : UserControl, IHomeComponent, IDragAndDropControl
    {
        bool clickDown = false;
        Point mouseDownLocation;
        PMInterPluginCall pmInterCall;

        protected Dictionary<int, string> handles = new Dictionary<int, string>();
        protected Dictionary<string, GbxCallbackHandler> Callbacks = new Dictionary<string, GbxCallbackHandler>();

        public HomeComponentPlugin()
        {        
            PluginType = PluginType.HomeComponent;
            Requirements = new List<Requirement>();
            handles = new Dictionary<int, string>();
            base.MouseClick += new MouseEventHandler(_mouseClick);
            base.MouseDown += new MouseEventHandler(_mouseDown);
            base.MouseUp += new MouseEventHandler(_mouseUp);
            base.MouseMove += new MouseEventHandler(_mouseMove);
        }
        public void setPluginManager(PMInterPluginCall pmipc)
        {
            this.pmInterCall = pmipc;
        }


        protected InterPluginResponse sendInterPluginCall(string target, string callName, Dictionary<string, object> args)
        {
            return pmInterCall(this, target, new InterPluginArgs(0, callName, args));
        }

        protected void asyncRequest(String methodeName, params object[] param)
        {
            if (param == null)
                param = new object[] { };

            if (this.client != null)
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
        /// <summary>
        /// Allows plugin movements from control (Edit Home Menu)
        /// </summary>
        /// <param name="ctrls"></param>
        protected void addMouseEvents(params Control[] ctrls)
        { 
            foreach (Control c in ctrls)
            {
                c.Click += (sender, e) => { this.OnClick(e); };
                c.MouseUp += (sender, e) => { this.OnMouseUp(e); };
                c.MouseDown += (sender, e) => { this.OnMouseDown(e); };
                c.MouseMove += (sender, e) => { this.OnMouseMove(e); };
            }
        }

        public void onGbxCallBack(object sender, GbxCallbackEventArgs args)
        {
            if (Callbacks.ContainsKey(args.Response.MethodName))
            {
                Callbacks[args.Response.MethodName](sender, args);
            }
            onGbxCallBack(args);
        }


        public string aliasCall(string arg)
        {
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Abstract ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public virtual void onDisconnect()
        {
        }

        public virtual void onLoad(LamaConfig cfg)
        { 
        }

        public virtual void onPluginUpdate()
        {

        }

        
        protected virtual void onGbxAsyncResult(GbxCall res)
        {   
        }

        public virtual void onGbxCallBack(GbxCallbackEventArgs res)
        {   
        }

        public void CheckCanMove()
        {
            this.CanMoveUp = (this.Location.Y > this.Parent.Location.Y);
            this.CanMoveDown = (this.Location.Y + this.Height < this.Parent.Location.Y + this.Parent.Height);
            this.CanMoveLeft = (this.Location.X > this.Parent.Location.X);
            this.CanMoveUp = (this.Location.X + this.Width < this.Parent.Location.X + this.Parent.Width);
        }

        private void _mouseMove(object sender, MouseEventArgs e)
        {
            if (clickDown && (bool)GetLamaProperty(LamaProperty.INEDITMODE))
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

        public InterPluginResponse onInterPluginCall(IBasePlugin sender, InterPluginArgs args)
        {
            return null;
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
        public GetLamaProperty GetLamaProperty { get; set; }
        public bool NeedXmlRpcConnection { get; set; }
        public string PluginDescription { get; set; }
    }
}
